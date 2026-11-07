# TRD — Technical Requirements Document

> **Versi**: 1.0 — Week 10 Deliverable  
> **Tanggal**: 4 November 2026

---

## 1. Technology Stack

| Komponen | Teknologi | Versi |
|----------|-----------|-------|
| **Runtime** | .NET | 10.0 |
| **Bahasa** | Visual Basic .NET (VB.NET) | — |
| **UI Framework** | Windows Forms | .NET 10 |
| **IDE** | Visual Studio | Terinstall |
| **Database** | MySQL | Running di localhost:3306 |
| **DB Connector** | MySql.Data (Connector/NET) | NuGet package |
| **Hashing** | System.Security.Cryptography (SHA-256) | Built-in .NET |
| **OS** | Windows 11 | — |

---

## 2. Arsitektur Aplikasi

```
┌──────────────────────────────────────────────────┐
│                   SIPELA Desktop                  │
├──────────────────────────────────────────────────┤
│  Presentation Layer (Windows Forms)               │
│  ┌────────────┐ ┌─────────────────┐ ┌──────────┐ │
│  │ frmLogin   │ │ frmMenuUtama    │ │ (future  │ │
│  │ frmMaster  │ │ frmMasterUsers  │ │  forms)  │ │
│  │ Lapangan   │ │                 │ │          │ │
│  └────────────┘ └─────────────────┘ └──────────┘ │
├──────────────────────────────────────────────────┤
│  Business Logic Layer (Modules)                   │
│  ┌────────────┐ ┌──────────────┐ ┌─────────────┐ │
│  │ ModKoneksi │ │ ModAutoNumber│ │ ModError    │ │
│  │            │ │              │ │ Handler     │ │
│  └────────────┘ └──────────────┘ └─────────────┘ │
│  ┌────────────┐                                   │
│  │ ModSesi    │                                   │
│  └────────────┘                                   │
├──────────────────────────────────────────────────┤
│  Data Layer (MySQL via MySql.Data)                │
│  ┌────────────────────────────────────────────┐   │
│  │ arung_futsal database                      │   │
│  │ Tables: users, lapangan, pemesanan,        │   │
│  │   detail_pemesanan, pembayaran, penomoran  │   │
│  └────────────────────────────────────────────┘   │
└──────────────────────────────────────────────────┘
```

---

## 3. Struktur Project

```
SIPELA-Sistem-Informasi-Pemesanan-Arung-Futsal/
├── .ai/                          # Planning documents
│   ├── PRD.md
│   ├── TRD.md
│   ├── APP-FLOW.md
│   ├── IMPLEMENTATION-PLAN.md
│   └── DESIGN.md
├── SIPELA/                       # VB.NET Solution root
│   ├── SIPELA.sln                # Solution file
│   └── SIPELA/                   # Project folder
│       ├── SIPELA.vbproj         # Project file (.NET 10)
│       ├── Program.vb            # Entry point
│       ├── Forms/
│       │   ├── frmLogin.vb             # Login form
│       │   ├── frmLogin.Designer.vb
│       │   ├── frmMenuUtama.vb         # Main menu form
│       │   ├── frmMenuUtama.Designer.vb
│       │   ├── frmMasterLapangan.vb    # Master lapangan form
│       │   ├── frmMasterLapangan.Designer.vb
│       │   ├── frmMasterUsers.vb       # Master users form
│       │   └── frmMasterUsers.Designer.vb
│       ├── Modules/
│       │   ├── ModKoneksi.vb           # Database connection
│       │   ├── ModAutoNumber.vb        # Auto-numbering logic
│       │   ├── ModErrorHandler.vb      # Error handling + logging
│       │   └── ModSesi.vb              # Session (logged-in user)
│       └── Resources/                  # Icons, images (optional)
├── Database/
│   └── arung_futsal.sql          # Database creation script
├── AGENTS.md
└── README.md
```

---

## 4. Database Specification

### 4.1 Tabel

#### `users`
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_user` | INT | PK, AUTO_INCREMENT | — |
| `username` | VARCHAR(50) | UNIQUE, NOT NULL | — |
| `password_hash` | VARCHAR(64) | NOT NULL | SHA-256 hex |
| `nama_lengkap` | VARCHAR(100) | NOT NULL | — |
| `role` | ENUM('Admin','Owner') | NOT NULL | — |
| `is_active` | BOOLEAN | DEFAULT TRUE | Soft delete |
| `gagal_login` | TINYINT | DEFAULT 0 | Counter gagal login |
| `terkunci_sampai` | DATETIME | NULL | Lock timestamp |
| `created_at` | DATETIME | DEFAULT CURRENT_TIMESTAMP | — |
| `updated_at` | DATETIME | ON UPDATE CURRENT_TIMESTAMP | — |

#### `jenis_lantai` (Master Pendukung ComboBox)
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_jenis` | INT | PK, AUTO_INCREMENT | — |
| `nama_jenis` | VARCHAR(50) | UNIQUE, NOT NULL | Rumput Sintetis, Vinyl, Interlock, dll |

#### `lapangan`
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_lapangan` | INT | PK, AUTO_INCREMENT | — |
| `nama_lapangan` | VARCHAR(50) | UNIQUE, NOT NULL | — |
| `jenis_lantai` | VARCHAR(50) | NOT NULL | vinyl/rumput sintetis/dll |
| `harga_per_jam` | DECIMAL(10,0) | NOT NULL, CHECK > 0 | — |
| `is_active` | BOOLEAN | DEFAULT TRUE | Soft delete |
| `created_at` | DATETIME | DEFAULT CURRENT_TIMESTAMP | — |
| `updated_at` | DATETIME | ON UPDATE CURRENT_TIMESTAMP | — |

#### `pemesanan` (struktur untuk SQL script, belum diimplementasi di form)
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_pemesanan` | INT | PK, AUTO_INCREMENT | — |
| `kode_booking` | VARCHAR(20) | UNIQUE, NOT NULL | BKG-YYYYMMDD-XXXX |
| `id_user` | INT | FK → users | Admin yang input |
| `nama_pemesan` | VARCHAR(100) | NOT NULL | — |
| `no_telepon` | VARCHAR(15) | NOT NULL | — |
| `waktu_dibuat` | DATETIME | DEFAULT CURRENT_TIMESTAMP | — |
| `batas_bayar` | DATETIME | NOT NULL | +15 menit dari waktu_dibuat |
| `total_sewa` | DECIMAL(12,0) | NOT NULL, CHECK > 0 | — |
| `jumlah_dp` | DECIMAL(12,0) | NOT NULL, CHECK > 0 | 30% dari total_sewa |
| `status_pemesanan` | ENUM('Menunggu DP','DP Terbayar','Lunas','Kedaluwarsa') | NOT NULL | — |
| `catatan` | TEXT | NULL | — |

#### `detail_pemesanan`
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_detail` | INT | PK, AUTO_INCREMENT | — |
| `id_pemesanan` | INT | FK → pemesanan | — |
| `id_lapangan` | INT | FK → lapangan | — |
| `tanggal_main` | DATE | NOT NULL | — |
| `jam_mulai` | TINYINT | NOT NULL, CHECK 8–23 | — |
| `harga_slot` | DECIMAL(10,0) | NOT NULL | Snapshot harga saat booking |
| `aktif` | BOOLEAN | DEFAULT TRUE | NULL = slot dilepas |

**UNIQUE** constraint: `(id_lapangan, tanggal_main, jam_mulai, aktif)` → anti double booking

#### `pembayaran`
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `id_pembayaran` | INT | PK, AUTO_INCREMENT | — |
| `no_transaksi` | VARCHAR(20) | UNIQUE, NOT NULL | PAY-YYYYMMDD-XXXX |
| `id_pemesanan` | INT | FK → pemesanan | — |
| `id_user` | INT | FK → users | Admin yang catat |
| `jenis_pembayaran` | ENUM('DP','Pelunasan') | NOT NULL | — |
| `jumlah_bayar` | DECIMAL(12,0) | NOT NULL, CHECK > 0 | — |
| `metode_pembayaran` | ENUM('Tunai','QRIS','Transfer') | NOT NULL | — |
| `waktu_bayar` | DATETIME | DEFAULT CURRENT_TIMESTAMP | — |

**UNIQUE** constraint: `(id_pemesanan, jenis_pembayaran)` → max 1 DP + 1 Pelunasan

#### `penomoran`
| Kolom | Tipe | Constraint | Keterangan |
|-------|------|-----------|------------|
| `jenis` | VARCHAR(10) | PK (composite) | 'BKG' atau 'PAY' |
| `tanggal` | DATE | PK (composite) | — |
| `nomor_terakhir` | INT | DEFAULT 0 | — |

### 4.2 Stored Procedures

| Nama | Fungsi |
|------|--------|
| `sp_nomor_berikutnya(p_jenis, p_tanggal, OUT p_nomor)` | Atomically increment dan return nomor berikutnya |
| `sp_kedaluwarsakan_pemesanan()` | Update status pemesanan yang melewati batas bayar |

### 4.3 Views

| Nama | Fungsi |
|------|--------|
| `v_jadwal_lapangan` | Gabungan jadwal slot per lapangan per tanggal |
| `v_pendapatan_bulanan` | Agregasi pendapatan per bulan |
| `v_okupansi_bulanan` | Persentase okupansi per bulan |
| `v_laporan_bulanan` | Gabungan pendapatan + okupansi + MoM |

### 4.4 Sample Data

| Tabel | Data |
|-------|------|
| `users` | owner/owner123 (Owner), admin/admin123 (Admin) |
| `lapangan` | Lapangan A (Vinyl, Rp 100.000), Lapangan B (Rumput Sintetis, Rp 120.000), Lapangan C (Vinyl, Rp 100.000) |

---

## 5. Modul Pendukung

### 5.1 `ModKoneksi.vb`
- Connection string: `Server=localhost;Port=3306;Database=arung_futsal;Uid=root;Pwd=;CharSet=utf8mb4;`
- Function `BukaKoneksi() As MySqlConnection` — buka dan return koneksi baru
- Error handling: tangkap `MySqlException` dan tampilkan pesan koneksi gagal

### 5.2 `ModAutoNumber.vb`
- Memanggil `sp_nomor_berikutnya` untuk generate kode booking dan nomor transaksi
- Untuk Week 10: belum digunakan di form master, tapi modul sudah disiapkan

### 5.3 `ModErrorHandler.vb`
- `Sub TampilkanError(kegiatan As String, ex As Exception)` — MessageBox ke user + log ke file
- `Sub LogError(ex As Exception)` — tulis detail error ke file log
- Try...Catch wrapper

### 5.4 `ModSesi.vb`
- `Property IdUser As Integer` — ID user yang login
- `Property Username As String`
- `Property NamaLengkap As String`
- `Property Role As String` — "Admin" atau "Owner"
- `Sub Logout()` — reset semua property

---

## 6. Security

| Aspek | Implementasi |
|-------|-------------|
| Password storage | SHA-256 hash (bukan plaintext) |
| Login brute force | Lock akun setelah 5x gagal, unlock otomatis setelah 15 menit |
| SQL Injection | Parameterized queries (`@parameter`) di semua query |
| Role-based access | Menu di `frmMenuUtama` di-enable/disable berdasarkan `ModSesi.Role` |
| Soft delete | Data tidak dihapus permanen, hanya `is_active = FALSE` |

---

## 7. NuGet Packages

| Package | Kegunaan | Catatan |
|---------|----------|---------|
| `MySql.Data` | MySQL Connector/NET | User akan install manual |
| *(future)* `Microsoft.Reporting.WinForms` | RDLC ReportViewer | Untuk frmLaporan nanti |

