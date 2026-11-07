-- =====================================================================
-- MIGRATION: master_jenis_lantai
-- PROYEK: SIPELA (Sistem Pemesanan Lapangan Arung Futsal)
-- TUJUAN: Menambahkan tabel master_jenis_lantai untuk memenuhi
--         rubrik penugasan Week 10 (ComboBox terhubung ke database)
-- =====================================================================

USE `arung_futsal`;

-- 1. Buat tabel master_jenis_lantai
CREATE TABLE IF NOT EXISTS `jenis_lantai` (
  `id_jenis` INT NOT NULL AUTO_INCREMENT,
  `nama_jenis` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_jenis`),
  UNIQUE KEY `uq_jenis_nama` (`nama_jenis`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 2. Isi data awal jenis lantai
INSERT IGNORE INTO `jenis_lantai` (`nama_jenis`) VALUES
('Rumput Sintetis'),
('Vinyl'),
('Interlock'),
('Semen / Plester');

