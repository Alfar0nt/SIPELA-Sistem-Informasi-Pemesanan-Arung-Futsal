-- =====================================================================
-- MIGRASI DATABASE SIPELA v2: VIEWS & STORED PROCEDURES
-- Proyek: SIPELA (Sistem Informasi Pemesanan Lapangan Arung Futsal)
-- Tujuan: Membuat / memperbarui Views dan Stored Procedures yang dibutuhkan
--         oleh modul Jadwal Matriks, Laporan Analitik, Auto-Expiration,
--         dan Penomoran Otomatis tanpa menghapus data tabel yang sudah ada.
-- =====================================================================

USE `arung_futsal`;

-- =====================================================================
-- 1. VIEWS
-- =====================================================================

-- 1.1 View: v_jadwal_lapangan
-- Digunakan oleh: frmJadwal (Kalender Matriks Jadwal Lapangan)
CREATE OR REPLACE VIEW `v_jadwal_lapangan` AS
SELECT
  dp.`id_detail`,
  l.`id_lapangan`,
  l.`nama_lapangan`,
  l.`jenis_lantai`,
  dp.`tanggal_main`,
  dp.`jam_mulai`,
  dp.`harga_slot`,
  p.`id_pemesanan`,
  p.`kode_booking`,
  p.`nama_pemesan`,
  p.`no_telepon`,
  p.`status_pemesanan`,
  CASE
    WHEN dp.`aktif` IS NULL THEN 'Tersedia'
    WHEN p.`status_pemesanan` = 'Menunggu DP' THEN 'Ditahan'
    ELSE 'Terisi'
  END AS `status_slot`
FROM `lapangan` l
JOIN `detail_pemesanan` dp ON l.`id_lapangan` = dp.`id_lapangan`
JOIN `pemesanan` p ON dp.`id_pemesanan` = p.`id_pemesanan`;

-- 1.2 View: v_pendapatan_bulanan
-- Agregasi pendapatan dan frekuensi transaksi per bulan
CREATE OR REPLACE VIEW `v_pendapatan_bulanan` AS
SELECT
  DATE_FORMAT(pb.`waktu_bayar`, '%Y-%m') AS `periode`,
  YEAR(pb.`waktu_bayar`) AS `tahun`,
  MONTH(pb.`waktu_bayar`) AS `bulan`,
  SUM(pb.`jumlah_bayar`) AS `total_pendapatan`,
  COUNT(DISTINCT pb.`id_pembayaran`) AS `total_transaksi`
FROM `pembayaran` pb
GROUP BY DATE_FORMAT(pb.`waktu_bayar`, '%Y-%m'), YEAR(pb.`waktu_bayar`), MONTH(pb.`waktu_bayar`);

-- 1.3 View: v_okupansi_bulanan
-- Perhitungan utilitas jam main lapangan (kapasitas: 16 jam operasional * jumlah hari * lapangan aktif)
CREATE OR REPLACE VIEW `v_okupansi_bulanan` AS
SELECT
  DATE_FORMAT(dp.`tanggal_main`, '%Y-%m') AS `periode`,
  COUNT(dp.`id_detail`) AS `slot_terisi`,
  ((SELECT COUNT(*) FROM `lapangan` WHERE `is_active` = TRUE) * 16 * DAY(LAST_DAY(dp.`tanggal_main`))) AS `kapasitas_slot`,
  ROUND((COUNT(dp.`id_detail`) / NULLIF(((SELECT COUNT(*) FROM `lapangan` WHERE `is_active` = TRUE) * 16 * DAY(LAST_DAY(dp.`tanggal_main`))), 0)) * 100, 2) AS `persen_okupansi`
FROM `detail_pemesanan` dp
WHERE dp.`aktif` = TRUE
GROUP BY DATE_FORMAT(dp.`tanggal_main`, '%Y-%m'), LAST_DAY(dp.`tanggal_main`);

-- 1.4 View: v_laporan_bulanan
-- Digunakan oleh: frmLaporan (Laporan & Analitik Pertumbuhan MoM)
CREATE OR REPLACE VIEW `v_laporan_bulanan` AS
SELECT
  p.`periode`,
  p.`total_pendapatan`,
  p.`total_transaksi`,
  COALESCE(o.`slot_terisi`, 0) AS `slot_terisi`,
  COALESCE(o.`kapasitas_slot`, 0) AS `kapasitas_slot`,
  COALESCE(o.`persen_okupansi`, 0) AS `persen_okupansi`
FROM `v_pendapatan_bulanan` p
LEFT JOIN `v_okupansi_bulanan` o ON p.`periode` = o.`periode`;

-- =====================================================================
-- 2. STORED PROCEDURES
-- =====================================================================

DELIMITER $$

-- 2.1 Stored Procedure: sp_nomor_berikutnya
-- Digunakan oleh: ModAutoNumber (Generate Kode Booking & No Transaksi)
DROP PROCEDURE IF EXISTS `sp_nomor_berikutnya`$$
CREATE PROCEDURE `sp_nomor_berikutnya`(
  IN p_jenis VARCHAR(10),
  IN p_tanggal DATE,
  OUT p_nomor INT
)
BEGIN
  INSERT INTO `penomoran` (`jenis`, `tanggal`, `nomor_terakhir`)
  VALUES (p_jenis, p_tanggal, 1)
  ON DUPLICATE KEY UPDATE `nomor_terakhir` = `nomor_terakhir` + 1;

  SELECT `nomor_terakhir` INTO p_nomor
  FROM `penomoran`
  WHERE `jenis` = p_jenis AND `tanggal` = p_tanggal;
END$$

-- 2.2 Stored Procedure: sp_kedaluwarsakan_pemesanan
-- Digunakan oleh: Background Timer frmMenuUtama (Auto-release expired hold)
DROP PROCEDURE IF EXISTS `sp_kedaluwarsakan_pemesanan`$$
CREATE PROCEDURE `sp_kedaluwarsakan_pemesanan`()
BEGIN
  -- Lepas slot booking yang melewati batas bayar DP
  UPDATE `detail_pemesanan` dp
  JOIN `pemesanan` p ON dp.`id_pemesanan` = p.`id_pemesanan`
  SET dp.`aktif` = NULL
  WHERE p.`status_pemesanan` = 'Menunggu DP'
    AND p.`batas_bayar` < NOW();

  -- Ubah status pemesanan menjadi Kedaluwarsa
  UPDATE `pemesanan`
  SET `status_pemesanan` = 'Kedaluwarsa'
  WHERE `status_pemesanan` = 'Menunggu DP'
    AND `batas_bayar` < NOW();
END$$

DELIMITER ;

-- =====================================================================
-- 3. VERIFIKASI (Jalankan query di bawah untuk memastikan berhasil)
-- =====================================================================
SHOW FULL TABLES IN `arung_futsal` WHERE Table_type = 'VIEW';
SHOW PROCEDURE STATUS WHERE Db = 'arung_futsal';

