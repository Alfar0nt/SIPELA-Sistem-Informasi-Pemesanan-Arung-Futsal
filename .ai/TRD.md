# TRD — Technical Requirements Document: SIPELA

> **Versi**: 2.1 — Full Operational Architecture  
> **Tanggal**: 5 November 2026  
> **Runtime Target**: .NET 10.0 Windows Forms (VB.NET)  
> **Database**: MySQL 8.0 / MariaDB InnoDB  
> **Status**: Fase Operasional Inti Selesai (Fase 9 s.d. 15) — 1 Bug Fix Analitik Terbuka

---

## 1. Technology Stack

| Komponen | Spesifikasi / Library | Versi | Peran Teknis |
|----------|----------------------|-------|--------------|
| **Framework Runtime** | .NET (Windows Desktop) | `net10.0-windows` | Lingkungan runtime aplikasi desktop |
| **Bahasa Pemrograman** | Visual Basic .NET (VB.NET) | 16.9+ | Sintaks logika bisnis dan presentation layer |
| **UI Presentation Layer** | Windows Forms (WinForms) | .NET 10 | Rendering form, custom painting, tactile micro-interactions |
| **Database Engine** | MySQL Server / MariaDB | 8.0+ | Penyimpanan relasional transaksi atomik (InnoDB) |
| **Database Connector** | `MySql.Data` | 26.10.0 | ADO.NET Data Provider untuk MySQL |
| **Kriptografi & Keamanan** | `System.Security.Cryptography` | Built-in | Hashing SHA-256 untuk password pengguna |
| **Mekanisme Cetak** | `System.Drawing.Printing` | Built-in | Generator struk nota transaksi thermal / slip bukti bayar |
| **Ekspor Data** | `System.IO` (CSV RFC 4180) | Built-in | Ekspor data tabular rekapitulasi ke format spreadsheet |

---

## 2. Arsitektur Perangkat Lunak 3-Tier

```
┌────────────────────────────────────────────────────────────────────────┐
│                        SIPELA DESKTOP CLIENT                           │
├────────────────────────────────────────────────────────────────────────┤
│  1. PRESENTATION LAYER (Windows Forms + Tactile Neo-Brutalism)          │
│  ┌──────────────┐ ┌──────────────┐ ┌──────────────┐ ┌──────────────┐   │
│  │ frmLogin     │ │ frmMenuUtama │ │ frmPemesanan │ │ frmPembayaran│   │
│  └──────────────┘ └──────────────┘ └──────────────┘ └──────────────┘   │
│  ┌──────────────┐ ┌──────────────┐ ┌──────────────┐ ┌──────────────┐   │
│  │ frmJadwal    │ │ frmLaporan   │ │ frmMasterLap │ │ frmMasterUser│   │
│  └──────────────┘ └──────────────┘ └──────────────┘ └──────────────┘   │
├────────────────────────────────────────────────────────────────────────┤
│  2. BUSINESS LOGIC LAYER (Modules & Helpers)                           │
│  ┌──────────────────────┐ ┌──────────────────────┐ ┌─────────────────┐ │
│  │ ModKoneksi           │ │ ModAutoNumber        │ │ ModErrorHandler │ │
│  │ (Pool & Connection)  │ │ (sp_nomor_berikutnya)│ │ (Logging & File)│ │
│  └──────────────────────┘ └──────────────────────┘ └─────────────────┘ │
│  ┌──────────────────────┐ ┌──────────────────────┐                     │
│  │ ModSesi              │ │ ModUIHelper          │                     │
│  │ (Current User Auth)  │ │ (Tactile Styling Eng)│                     │
│  └──────────────────────┘ └──────────────────────┘                     │
├────────────────────────────────────────────────────────────────────────┤
│  3. DATA ACCESS LAYER (MySQL via MySql.Data - InnoDB Engine)           │
│  ┌──────────────────────────────────────────────────────────────────┐  │
│  │ Database: arung_futsal (Charset: utf8mb4)                        │  │
│  │ • Tables: users, lapangan, pemesanan, detail_pemesanan,          │  │
│  │           pembayaran, penomoran                                  │  │
│  │ • Stored Procedures: sp_nomor_berikutnya,                        │  │
│  │                      sp_kedaluwarsakan_pemesanan                 │  │
│  │ • Views: v_jadwal_lapangan, v_pendapatan_bulanan,                │  │
│  │          v_okupansi_bulanan, v_laporan_bulanan                   │  │
│  └──────────────────────────────────────────────────────────────────┘  │
└────────────────────────────────────────────────────────────────────────┘
```

---

## 3. Struktur Direktori Proyek

```
SIPELA-Sistem-Informasi-Pemesanan-Arung-Futsal/
├── .ai/                                  # Dokumentasi Sistem Terpadu
│   ├── PRD.md                            # Product Requirements Document
│   ├── TRD.md                            # Technical Requirements Document
│   ├── APP-FLOW.md                       # Mermaid Workflows & Navigation
│   ├── IMPLEMENTATION-PLAN.md            # Master Plan Operasional
│   └── DESIGN.md                         # Tactile Neo-Brutalism Guidelines
├── .agents/                              # Agent Skills Directory
│   └── skills/
│       ├── dotnet-best-practices/        # Standar kode .NET & resource disposal
│       ├── find-skills/                  # Skill discovery engine
│       ├── 9router/                      # AI gateway support
│       └── herdr/                        # Multiplexing support
├── Database/
│   ├── arung_futsal.sql                  # Skrip DDL & DML skema database
│   └── migration_v2_views_procedures.sql # Migrasi v2: views & stored procedures (re-runable)
├── pics/                                 # Tangkapan layar aplikasi (dipakai README)
│   ├── homepage-admin.png
│   ├── pemesanan.png
│   └── daftar-sewa.png
├── README.md                             # Ringkasan proyek, fitur, & screenshot
├── SIPELA/                               # Root Solusi VB.NET
│   ├── SIPELA.slnx                       # Solution File
│   ├── SIPELA.vbproj                     # Project File (.NET 10 WinForms)
│   ├── Forms/
│   │   ├── frmLogin.vb                   # Autentikasi pengguna
│   │   ├── frmLogin.Designer.vb
│   │   ├── frmMenuUtama.vb               # Dasbor utama & navigasi
│   │   ├── frmMenuUtama.Designer.vb
│   │   ├── frmMasterLapangan.vb          # CRUD data lapangan
│   │   ├── frmMasterLapangan.Designer.vb
│   │   ├── frmMasterUsers.vb             # CRUD akun pengguna
│   │   ├── frmMasterUsers.Designer.vb
│   │   ├── frmPemesanan.vb               # Transaksi booking & slot jam
│   │   ├── frmPemesanan.Designer.vb
│   │   ├── frmPembayaran.vb              # Transaksi kasir DP & pelunasan
│   │   ├── frmPembayaran.Designer.vb
│   │   ├── frmJadwal.vb                  # Matriks kalender jadwal visual
│   │   ├── frmJadwal.Designer.vb
│   │   ├── frmLaporan.vb                 # Dasbor rekapitulasi & ekspor
│   │   ├── frmLaporan.Designer.vb
│   │   ├── frmNotaPreview.vb             # Pratinjau & cetak struk sewa
│   │   └── frmNotaPreview.Designer.vb
│   ├── Modules/
│   │   ├── ModKoneksi.vb                 # Koneksi & transaksi MySQL
│   │   ├── ModSesi.vb                    # Sesi pengguna aktif & role
│   │   ├── ModErrorHandler.vb            # Penanganan error & logger file
│   │   ├── ModAutoNumber.vb              # Penomoran otomatis berbasis DB SP
│   │   └── ModUIHelper.vb                # Engine gaya Tactile Neo-Brutalism
│   └── My Project/
│       ├── Application.myapp             # Application framework settings
│       └── Application.Designer.vb
└── AGENTS.md                             # Aturan interaksi & eksekusi agen
```

---

## 4. Spesifikasi Database & Relasi

### 4.1 Tabel-Tabel Inti

1. **`users`**:
   - `id_user` INT PK AUTO_INCREMENT
   - `username` VARCHAR(50) UNIQUE NOT NULL
   - `password_hash` VARCHAR(64) NOT NULL (SHA-256)
   - `nama_lengkap` VARCHAR(100) NOT NULL
   - `role` ENUM('Admin', 'Owner') NOT NULL
   - `is_active` BOOLEAN DEFAULT TRUE (Soft-delete)
   - `gagal_login` TINYINT DEFAULT 0
   - `terkunci_sampai` DATETIME NULL (Proteksi brute-force)

2. **`lapangan`**:
   - `id_lapangan` INT PK AUTO_INCREMENT
   - `nama_lapangan` VARCHAR(50) UNIQUE NOT NULL
   - `jenis_lantai` VARCHAR(50) NOT NULL
   - `harga_per_jam` DECIMAL(10,0) NOT NULL (CHECK > 0)
   - `is_active` BOOLEAN DEFAULT TRUE

3. **`pemesanan`**:
   - `id_pemesanan` INT PK AUTO_INCREMENT
   - `kode_booking` VARCHAR(20) UNIQUE NOT NULL (`BKG-YYYYMMDD-XXXX`)
   - `id_user` INT FK → users
   - `nama_pemesan` VARCHAR(100) NOT NULL
   - `no_telepon` VARCHAR(15) NOT NULL
   - `waktu_dibuat` DATETIME DEFAULT CURRENT_TIMESTAMP
   - `batas_bayar` DATETIME NOT NULL (+15 menit)
   - `total_sewa` DECIMAL(12,0) NOT NULL
   - `jumlah_dp` DECIMAL(12,0) NOT NULL (30% dari total)
   - `status_pemesanan` ENUM('Menunggu DP', 'DP Terbayar', 'Lunas', 'Kedaluwarsa')
   - `catatan` TEXT NULL

4. **`detail_pemesanan`**:
   - `id_detail` INT PK AUTO_INCREMENT
   - `id_pemesanan` INT FK → pemesanan
   - `id_lapangan` INT FK → lapangan
   - `tanggal_main` DATE NOT NULL
   - `jam_mulai` TINYINT NOT NULL (CHECK 8 s.d. 23)
   - `harga_slot` DECIMAL(10,0) NOT NULL
   - `aktif` BOOLEAN DEFAULT TRUE
   - **Kunci Unik Komposit**: `UNIQUE (id_lapangan, tanggal_main, jam_mulai, aktif)` untuk mencegah slot ganda.

5. **`pembayaran`**:
   - `id_pembayaran` INT PK AUTO_INCREMENT
   - `no_transaksi` VARCHAR(20) UNIQUE NOT NULL (`PAY-YYYYMMDD-XXXX`)
   - `id_pemesanan` INT FK → pemesanan
   - `id_user` INT FK → users
   - `jenis_pembayaran` ENUM('DP', 'Pelunasan') NOT NULL
   - `jumlah_bayar` DECIMAL(12,0) NOT NULL
   - `metode_pembayaran` ENUM('Tunai', 'QRIS', 'Transfer') NOT NULL
   - `waktu_bayar` DATETIME DEFAULT CURRENT_TIMESTAMP
   - **Kunci Unik Komposit**: `UNIQUE (id_pemesanan, jenis_pembayaran)`

6. **`penomoran`**:
   - `jenis` VARCHAR(10) PK, `tanggal` DATE PK, `nomor_terakhir` INT DEFAULT 0

### 4.2 Stored Procedures & Views

- **`sp_nomor_berikutnya(p_jenis, p_tanggal, OUT p_nomor)`**: Mengamankan nomor urut harian secara atomik menggunakan `INSERT ... ON DUPLICATE KEY UPDATE`.
- **`sp_kedaluwarsakan_pemesanan()`**: Mengubah status pemesanan yang melewati `batas_bayar` menjadi `'Kedaluwarsa'`, serta menonaktifkan slot di `detail_pemesanan` (`SET aktif = NULL`) agar kembali tersedia.
- **`v_jadwal_lapangan`**: Berguna untuk mengisi matriks jadwal harian.
- **`v_laporan_bulanan`**: Menyajikan ringkasan omzet, okupansi, dan tren pertumbuhan MoM.

---

## 5. Spesifikasi Teknis Modul Pendukung

### 5.1 `ModUIHelper.vb` (Tactile Claymorphism Engine)
- Menyediakan metode ekstensi dan subroutine untuk:
  - `TerapkanTemaForm(form)`: Mengatur BackColor ke Warm Cream `#FDFBF7`, default font, dan DoubleBuffered.
  - `TerapkanGayaTombol(button, jenisWarna)`: Menerapkan FlatStyle, border 2px solid Dark Slate `#2D334A`, padding, dan hook interaksi klik mekanis.
  - `TerapkanGayaCard(panel)`: Menambahkan border tegas dan solid offset shadow.
  - `TerapkanGayaGrid(dgv)`: Konfigurasi lengkap header dark slate, zebra row pastel, dan seleksi sky blue.

### 5.2 Pencetakan Struk (`System.Drawing.Printing.PrintDocument`)
- Render nota dalam format teks terstruktur atau format grafis (2D Canvas) dengan dimensi slip standar kasir (80 mm / 300 DPI):
  - Menggambar logo Arung Futsal, informasi kode sewa, rincian pembayaran, dan barcode/garis batas.
  - Opsi *Print to Default Printer* atau pratinjau modal di form `frmNotaPreview`.

### 5.3 Ekspor Data Spreadsheet
- Generator CSV terstandarisasi dengan pemisah titik koma (`;`) atau koma (`,`) serta penanganan karakter khusus (kutip ganda dan newline).
- Menghasilkan file yang kompatibel langsung dengan Microsoft Excel, LibreOffice Calc, dan Google Sheets.
