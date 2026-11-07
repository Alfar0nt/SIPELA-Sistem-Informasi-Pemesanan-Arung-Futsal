-- =====================================================================
-- DATABASE: arung_futsal
-- PROYEK: SIPELA (Sistem Pemesanan Lapangan Arung Futsal)
-- MATA KULIAH: Pemrograman Desktop
-- =====================================================================

CREATE DATABASE IF NOT EXISTS `arung_futsal`
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE `arung_futsal`;

SET FOREIGN_KEY_CHECKS = 0;

-- ---------------------------------------------------------------------
-- 1. TABEL: users
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `users` (
  `id_user` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(50) NOT NULL,
  `password_hash` VARCHAR(64) NOT NULL,
  `nama_lengkap` VARCHAR(100) NOT NULL,
  `role` ENUM('Admin', 'Owner') NOT NULL,
  `is_active` BOOLEAN NOT NULL DEFAULT TRUE,
  `gagal_login` TINYINT NOT NULL DEFAULT 0,
  `terkunci_sampai` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `uq_users_username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Pastikan id_user memiliki AUTO_INCREMENT jika tabel sudah pernah dibuat sebelumnya
ALTER TABLE `users` MODIFY COLUMN `id_user` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 2. TABEL: jenis_lantai (Master Data Pendukung untuk ComboBox Lapangan)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `jenis_lantai` (
  `id_jenis` INT NOT NULL AUTO_INCREMENT,
  `nama_jenis` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_jenis`),
  UNIQUE KEY `uq_jenis_nama` (`nama_jenis`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

ALTER TABLE `jenis_lantai` MODIFY COLUMN `id_jenis` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 3. TABEL: lapangan
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `lapangan` (
  `id_lapangan` INT NOT NULL AUTO_INCREMENT,
  `nama_lapangan` VARCHAR(50) NOT NULL,
  `jenis_lantai` VARCHAR(50) NOT NULL,
  `harga_per_jam` DECIMAL(10, 0) NOT NULL,
  `is_active` BOOLEAN NOT NULL DEFAULT TRUE,
  PRIMARY KEY (`id_lapangan`),
  UNIQUE KEY `uq_lapangan_nama` (`nama_lapangan`),
  CONSTRAINT `chk_harga_positif` CHECK (`harga_per_jam` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Pastikan id_lapangan memiliki AUTO_INCREMENT jika tabel sudah pernah dibuat sebelumnya
ALTER TABLE `lapangan` MODIFY COLUMN `id_lapangan` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 4. TABEL: pemesanan
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pemesanan` (
  `id_pemesanan` INT NOT NULL AUTO_INCREMENT,
  `kode_booking` VARCHAR(20) NOT NULL,
  `id_user` INT NOT NULL,
  `nama_pemesan` VARCHAR(100) NOT NULL,
  `no_telepon` VARCHAR(15) NOT NULL,
  `waktu_dibuat` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `batas_bayar` DATETIME NOT NULL,
  `total_sewa` DECIMAL(12, 0) NOT NULL,
  `jumlah_dp` DECIMAL(12, 0) NOT NULL,
  `status_pemesanan` ENUM('Menunggu DP', 'DP Terbayar', 'Lunas', 'Kedaluwarsa') NOT NULL DEFAULT 'Menunggu DP',
  `catatan` TEXT NULL,
  PRIMARY KEY (`id_pemesanan`),
  UNIQUE KEY `uq_pemesanan_kode` (`kode_booking`),
  CONSTRAINT `chk_total_sewa_positif` CHECK (`total_sewa` > 0),
  CONSTRAINT `chk_jumlah_dp_valid` CHECK (`jumlah_dp` > 0 AND `jumlah_dp` <= `total_sewa`),
  CONSTRAINT `fk_pemesanan_user` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

ALTER TABLE `pemesanan` MODIFY COLUMN `id_pemesanan` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 4. TABEL: detail_pemesanan
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `detail_pemesanan` (
  `id_detail` INT NOT NULL AUTO_INCREMENT,
  `id_pemesanan` INT NOT NULL,
  `id_lapangan` INT NOT NULL,
  `tanggal_main` DATE NOT NULL,
  `jam_mulai` TINYINT NOT NULL,
  `harga_slot` DECIMAL(10, 0) NOT NULL,
  `aktif` BOOLEAN NULL DEFAULT TRUE,
  PRIMARY KEY (`id_detail`),
  CONSTRAINT `chk_jam_operasional` CHECK (`jam_mulai` BETWEEN 8 AND 23),
  CONSTRAINT `chk_harga_slot_positif` CHECK (`harga_slot` > 0),
  CONSTRAINT `uq_slot_aktif` UNIQUE (`id_lapangan`, `tanggal_main`, `jam_mulai`, `aktif`),
  CONSTRAINT `fk_detail_pemesanan` FOREIGN KEY (`id_pemesanan`) REFERENCES `pemesanan` (`id_pemesanan`) ON DELETE RESTRICT,
  CONSTRAINT `fk_detail_lapangan` FOREIGN KEY (`id_lapangan`) REFERENCES `lapangan` (`id_lapangan`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

ALTER TABLE `detail_pemesanan` MODIFY COLUMN `id_detail` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 5. TABEL: pembayaran
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pembayaran` (
  `id_pembayaran` INT NOT NULL AUTO_INCREMENT,
  `no_transaksi` VARCHAR(20) NOT NULL,
  `id_pemesanan` INT NOT NULL,
  `id_user` INT NOT NULL,
  `jenis_pembayaran` ENUM('DP', 'Pelunasan') NOT NULL,
  `jumlah_bayar` DECIMAL(12, 0) NOT NULL,
  `metode_pembayaran` ENUM('Tunai', 'QRIS', 'Transfer') NOT NULL,
  `waktu_bayar` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_pembayaran`),
  UNIQUE KEY `uq_pembayaran_transaksi` (`no_transaksi`),
  UNIQUE KEY `uq_pemesanan_jenis` (`id_pemesanan`, `jenis_pembayaran`),
  CONSTRAINT `chk_jumlah_bayar_positif` CHECK (`jumlah_bayar` > 0),
  CONSTRAINT `fk_pembayaran_pemesanan` FOREIGN KEY (`id_pemesanan`) REFERENCES `pemesanan` (`id_pemesanan`) ON DELETE RESTRICT,
  CONSTRAINT `fk_pembayaran_user` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

ALTER TABLE `pembayaran` MODIFY COLUMN `id_pembayaran` INT NOT NULL AUTO_INCREMENT;

-- ---------------------------------------------------------------------
-- 6. TABEL: penomoran (Auto Number Generator)
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `penomoran` (
  `jenis` VARCHAR(10) NOT NULL,
  `tanggal` DATE NOT NULL,
  `nomor_terakhir` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`jenis`, `tanggal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

SET FOREIGN_KEY_CHECKS = 1;

-- ---------------------------------------------------------------------
-- 7. STORED PROCEDURES
-- ---------------------------------------------------------------------
DELIMITER $$

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

-- ---------------------------------------------------------------------
-- 8. VIEWS
-- ---------------------------------------------------------------------

-- View: v_jadwal_lapangan
CREATE OR REPLACE VIEW `v_jadwal_lapangan` AS
SELECT
  dp.`id_detail`,
  l.`id_lapangan`,
  l.`nama_lapangan`,
  l.`jenis_lantai`,
  dp.`tanggal_main`,
  dp.`jam_mulai`,
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

-- View: v_pendapatan_bulanan
CREATE OR REPLACE VIEW `v_pendapatan_bulanan` AS
SELECT
  DATE_FORMAT(pb.`waktu_bayar`, '%Y-%m') AS `periode`,
  YEAR(pb.`waktu_bayar`) AS `tahun`,
  MONTH(pb.`waktu_bayar`) AS `bulan`,
  SUM(pb.`jumlah_bayar`) AS `total_pendapatan`,
  COUNT(DISTINCT pb.`id_pembayaran`) AS `total_transaksi`
FROM `pembayaran` pb
GROUP BY DATE_FORMAT(pb.`waktu_bayar`, '%Y-%m'), YEAR(pb.`waktu_bayar`), MONTH(pb.`waktu_bayar`);

-- View: v_okupansi_bulanan
CREATE OR REPLACE VIEW `v_okupansi_bulanan` AS
SELECT
  DATE_FORMAT(dp.`tanggal_main`, '%Y-%m') AS `periode`,
  COUNT(dp.`id_detail`) AS `slot_terisi`,
  -- Total kapasitas per bulan: lapangan aktif * 16 slot * hari dalam bulan
  ((SELECT COUNT(*) FROM `lapangan` WHERE `is_active` = TRUE) * 16 * DAY(LAST_DAY(dp.`tanggal_main`))) AS `kapasitas_slot`,
  ROUND((COUNT(dp.`id_detail`) / NULLIF(((SELECT COUNT(*) FROM `lapangan` WHERE `is_active` = TRUE) * 16 * DAY(LAST_DAY(dp.`tanggal_main`))), 0)) * 100, 2) AS `persen_okupansi`
FROM `detail_pemesanan` dp
WHERE dp.`aktif` = TRUE
GROUP BY DATE_FORMAT(dp.`tanggal_main`, '%Y-%m'), LAST_DAY(dp.`tanggal_main`);

-- View: v_laporan_bulanan
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

-- ---------------------------------------------------------------------
-- 9. DATA AWAL (SEED DATA)
-- ---------------------------------------------------------------------

-- Master Jenis Lantai
INSERT IGNORE INTO `jenis_lantai` (`nama_jenis`) VALUES
  ('Rumput Sintetis'),
  ('Vinyl'),
  ('Interlock'),
  ('Semen / Plester');

-- Users demo (password hash SHA-256)
-- owner: owner123 -> 43a0d17178a9d26c9e0fe9a74b0b45e38d32f27aed887a008a54bf6e033bf7b9
-- admin: admin123 -> 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
INSERT IGNORE INTO `users` (`username`, `password_hash`, `nama_lengkap`, `role`, `is_active`)
VALUES
  ('owner', '43a0d17178a9d26c9e0fe9a74b0b45e38d32f27aed887a008a54bf6e033bf7b9', 'Pemilik Usaha Arung Futsal', 'Owner', TRUE),
  ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Staf Resepsionis Kasir', 'Admin', TRUE);

-- Master Lapangan awal
INSERT IGNORE INTO `lapangan` (`nama_lapangan`, `jenis_lantai`, `harga_per_jam`, `is_active`)
VALUES
  ('Lapangan A', 'Vinyl', 100000, TRUE),
  ('Lapangan B', 'Rumput Sintetis', 120000, TRUE),
  ('Lapangan C', 'Vinyl', 100000, TRUE);
