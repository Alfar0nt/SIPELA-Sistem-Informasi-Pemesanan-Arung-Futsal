# TRD — Technical Requirements Document

> **Versi**: 1.2 — Week 10, Week 11, & Week 12 Deliverable  
> **Tanggal**: 18 November 2026

---

## 1. Technology Stack

| Komponen | Teknologi | Versi / Catatan |
|----------|-----------|-----------------|
| **Runtime** | .NET | `net10.0-windows` (.NET 10.0) |
| **Bahasa** | Visual Basic .NET (VB.NET) | `Option Strict On`, `Option Explicit On` |
| **UI Framework** | Windows Forms | .NET 10 WinForms (Designer-compatible) |
| **IDE** | Visual Studio 2022+ / .NET CLI | `SIPELA.slnx` |
| **Database** | MySQL / MariaDB | Running di `localhost:3306` (`arung_futsal`) |
| **DB Connector** | `MySql.Data` (Connector/NET) | NuGet `v26.10.0` |
| **Hashing** | `System.Security.Cryptography` (SHA-256) | Built-in .NET |
| **Reporting & Export** | `System.Drawing.Printing.PrintDocument` + `PrintPreviewDialog` + Native UTF-8 BOM CSV Exporter | 0 dependency eksternal, 100% stabil di .NET 10 |
| **OS** | Windows 11 | — |

---

## 2. Arsitektur Aplikasi

```
┌────────────────────────────────────────────────────────────────┐
│                        SIPELA Desktop                          │
├────────────────────────────────────────────────────────────────┤
│  Presentation Layer (Windows Forms — Namespace SIPELA.Forms)   │
│  ┌──────────────┐ ┌───────────────────┐ ┌────────────────────┐ │
│  │ frmLogin     │ │ frmMasterLapangan │ │ frmPemesanan       │ │
│  │ frmMenuUtama │ │ frmMasterUsers    │ │ frmLaporan (Owner) │ │
│  └──────────────┘ └───────────────────┘ └────────────────────┘ │
├────────────────────────────────────────────────────────────────┤
│  Business Logic & Utility Layer (Modules)                      │
│  ┌──────────────┐ ┌───────────────────┐ ┌────────────────────┐ │
│  │ ModKoneksi   │ │ ModAutoNumber     │ │ ModErrorHandler    │ │
│  │ ModSesi      │ │ ModUIHelper       │ │                    │ │
│  └──────────────┘ └───────────────────┘ └────────────────────┘ │
├────────────────────────────────────────────────────────────────┤
│  Data Layer (MySQL via MySql.Data)                             │
│  ┌──────────────────────────────────────────────────────────┐  │
│  │ Database: arung_futsal                                   │  │
│  │ Tables : users, jenis_lantai, lapangan, pemesanan,       │  │
│  │          detail_pemesanan, pembayaran, penomoran         │  │
│  │ Views  : v_jadwal_lapangan, v_pendapatan_bulanan,        │  │
│  │          v_okupansi_bulanan, v_laporan_bulanan           │  │
│  │ SP     : sp_nomor_berikutnya, sp_kedaluwarsakan_pemesanan│  │
│  └──────────────────────────────────────────────────────────┘  │
└────────────────────────────────────────────────────────────────┘
```

---

## 3. Struktur Project

```
SIPELA-Sistem-Informasi-Pemesanan-Arung-Futsal/
├── .ai/                                  # Planning & architecture documents
│   ├── APP-FLOW.md
│   ├── DESIGN.md
│   ├── IMPLEMENTATION-PLAN.md
│   ├── PRD.md
│   └── TRD.md
├── Database/
│   ├── arung_futsal.sql                  # Full database DDL, SP, Views, Seed data
│   └── migration_jenis_lantai.sql        # Supporting migration for jenis_lantai
├── SIPELA/                               # VB.NET WinForms Solution & Project
│   ├── SIPELA.slnx                       # Solution file
│   ├── SIPELA.vbproj                     # SDK Project (.NET 10, explicit SubType/DependentUpon)
│   ├── ApplicationEvents.vb
│   ├── Forms/
│   │   ├── frmLogin.{vb,Designer.vb,resx}
│   │   ├── frmMenuUtama.{vb,Designer.vb,resx}
│   │   ├── frmMasterLapangan.{vb,Designer.vb,resx}
│   │   ├── frmMasterUsers.{vb,Designer.vb,resx}
│   │   ├── frmPemesanan.{vb,Designer.vb,resx}
│   │   └── frmLaporan.{vb,Designer.vb,resx}
│   ├── Modules/
│   │   ├── ModKoneksi.vb                 # Reusable MySQL connection
│   │   ├── ModAutoNumber.vb              # Atomic BKG/PAY auto-number + MySqlTransaction
│   │   ├── ModErrorHandler.vb            # Error dialogs & logging
│   │   ├── ModSesi.vb                    # Active user session & role checks
│   │   └── ModUIHelper.vb                # Standard 16×16 button icons & alignment
│   ├── Resources/Icons/                  # 16×16 PNG icons (insert, update, delete, clear, deactivate)
│   └── My Project/
│       ├── Application.Designer.vb       # Startup form: frmLogin
│       └── Application.myapp
├── AGENTS.md
└── README.md
```

---

## 4. Database Specification

### 4.1 Tabel Utama

| Tabel | Primary Key | Relasi / Constraint Kunci | Status Implementasi |
|---|---|---|---|
| `users` | `id_user` | `UNIQUE(username)`, `ENUM('Admin','Owner')`, SHA-256 hash, brute-force lock | ✅ `frmLogin`, `frmMasterUsers` |
| `jenis_lantai` | `id_jenis` | `UNIQUE(nama_jenis)` — sumber ComboBox DB | ✅ `frmMasterLapangan` |
| `lapangan` | `id_lapangan` | `UNIQUE(nama_lapangan)`, `CHECK(harga_per_jam > 0)` | ✅ `frmMasterLapangan`, `frmPemesanan`, `frmLaporan` |
| `pemesanan` | `id_pemesanan` | `UNIQUE(kode_booking)`, FK `id_user`, `ENUM('Menunggu DP','DP Terbayar','Lunas','Kedaluwarsa')` | ✅ `frmPemesanan`, `frmLaporan` |
| `detail_pemesanan` | `id_detail` | FK `id_pemesanan` & `id_lapangan`, `CHECK(jam_mulai BETWEEN 8 AND 23)`, `UNIQUE(id_lapangan, tanggal_main, jam_mulai, aktif)` | ✅ `frmPemesanan`, `frmLaporan` |
| `pembayaran` | `id_pembayaran` | `UNIQUE(no_transaksi)`, `UNIQUE(id_pemesanan, jenis_pembayaran)`, FK `id_pemesanan` & `id_user` | ✅ `frmPemesanan`, `frmLaporan` |
| `penomoran` | `(jenis, tanggal)` | Atomic counter harian untuk prefix `BKG` & `PAY` | ✅ `ModAutoNumber` |

### 4.2 Stored Procedures & Views

| Objek | Tipe | Kegunaan |
|---|---|---|
| `sp_nomor_berikutnya` | Stored Procedure | Increment atomik nomor urut `BKG` / `PAY` harian |
| `sp_kedaluwarsakan_pemesanan` | Stored Procedure | Kedaluwarsakan booking yang melewati batas bayar |
| `v_jadwal_lapangan` | View | Status slot per lapangan & tanggal |
| `v_pendapatan_bulanan` | View | Agregasi pendapatan & transaksi pembayaran per bulan |
| `v_okupansi_bulanan` | View | Persentase okupansi slot aktif per bulan |
| `v_laporan_bulanan` | View | Gabungan pendapatan & okupansi bulanan (digunakan di Tab 2 `frmLaporan`, lengkap dengan fallback query) |

---

## 5. Modul Pendukung

- **`ModKoneksi.vb`**: Koneksi terpusat ke `arung_futsal` (`Server=localhost;Port=3306;Database=arung_futsal;Uid=root;Pwd=;CharSet=utf8mb4;`) dengan handling `MySqlException`.
- **`ModAutoNumber.vb`**: Memanggil `sp_nomor_berikutnya` dengan dukungan `MySqlTransaction` dan 2 lapis fallback query.
- **`ModErrorHandler.vb`**: Wrapper `TampilkanError`, `TampilkanPeringatan`, `TampilkanInfo`, `Konfirmasi`, dan pencatatan log error.
- **`ModSesi.vb`**: Menyimpan `IdUser`, `Username`, `NamaLengkap`, `Role`, serta properti `IsLoggedIn`, `IsOwner`, `IsAdmin`.
- **`ModUIHelper.vb`**: Memuat icon PNG 16×16 px lokal (dengan fallback GDI+) dan menerapkan properti tombol (`ImageAlign = MiddleCenter`, `TextAlign = MiddleRight`, `TextImageRelation = ImageBeforeText`).

---

## 6. Spesifikasi Teknis Pelaporan (`frmLaporan` — Week 12)

1. **Query Relasional Terparameter**:
   - Tab 1 melakukan `INNER JOIN` pada `detail_pemesanan`, `pemesanan`, `lapangan`, `users` dan `LEFT JOIN` subquery agregasi `pembayaran` berdasarkan filter tanggal (`Tanggal Main` atau `Tanggal Pesan`), `id_lapangan`, `status_pemesanan`, dan pencarian teks.
   - Tab 2 membaca View `v_laporan_bulanan` dengan filter tahun + fallback query langsung jika view belum terpasang.
2. **Agregasi Anti Double-Counting & Null-Safe**:
   - Menggunakan `HashSet(Of Integer)` atas `id_pemesanan` agar `Total Pembayaran Masuk` dan `Sisa Belum Lunas` tidak terhitung ganda pada booking multi-slot.
   - Menggunakan helper `SafeString`, `SafeInt`, `SafeDecimal`, `SafeDate` untuk mencegah error `InvalidCastException` saat nilai `DBNull`.
3. **Ekspor CSV (Excel-Ready)**:
   - Encoding `UTF8Encoding(True)` (UTF-8 dengan BOM) + escaping RFC 4180 agar file langsung terbuka rapi di Microsoft Excel beserta header filter dan blok ringkasan agregasi.
4. **Cetak & Save as PDF (`PrintDocument` + `PrintPreviewDialog`)**:
   - Mendukung 3 mode cetak: Laporan Transaksi & Pendapatan (Landscape multi-halaman otomatis), Struk / Invoice Booking Terpilih (Portrait dinamis per `kode_booking`), dan Ringkasan Bulanan & Okupansi (Portrait).

---

## 7. Security & NuGet Packages

| Aspek / Package | Detail |
|---|---|
| **Password & Auth** | SHA-256 hash + lock 15 menit setelah 5× gagal login |
| **SQL Injection** | 100% Parameterized queries (`@parameter`) |
| **Role-Based Access** | `frmMasterUsers` dan `frmLaporan` dibatasi khusus **Owner** (dijaga di `frmMenuUtama` sekaligus di `Form_Load` masing-masing form) |
| **NuGet: `MySql.Data` v26.10.0** | Terpasang di `SIPELA.vbproj` |
