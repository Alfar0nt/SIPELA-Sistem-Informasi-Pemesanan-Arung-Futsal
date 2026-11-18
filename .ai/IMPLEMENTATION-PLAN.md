# IMPLEMENTATION-PLAN — Rencana Implementasi

> **Versi**: 1.2 — Week 10, Week 11, & Week 12 Deliverable  
> **Tanggal**: 18 November 2026  
> **Status**: Selesai Diimplementasikan (Terverifikasi `dotnet build` — 0 Warning, 0 Error)

---

## Ringkasan

Total **10 fase**, diurutkan berdasarkan dependensi. Seluruh fase 1 s.d. 10 (Week 10 Master Forms, Week 11 Transaksi Master-Detail, dan Week 12 Laporan & Ekspor/Cetak) telah berhasil diimplementasikan dan diverifikasi tanpa error.

---

## Fase 1: Project Setup

**Tujuan**: Buat project VB.NET Windows Forms .NET 10

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 1.1 | Buat solution dan project | Solusi & WinForms .NET 10 VB.NET | [x] Selesai | `SIPELA/SIPELA.slnx`, `SIPELA/SIPELA.vbproj` |
| 1.2 | Buat folder struktur | Buat `Forms/`, `Modules/` di dalam folder project | [x] Selesai | Folder `Forms/`, `Modules/` |
| 1.3 | Konfigurasi `.vbproj` | Target `net10.0-windows`, `WinExe`, `UseWindowsForms` | [x] Selesai | `SIPELA/SIPELA.vbproj` |

**Checkpoint**: `dotnet build` berhasil tanpa error. [x]

---

## Fase 2: Database — SQL Script

**Tujuan**: Buat skrip SQL lengkap untuk database `arung_futsal`

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 2.1 | CREATE DATABASE | `CREATE DATABASE IF NOT EXISTS arung_futsal` | [x] Selesai | `Database/arung_futsal.sql` |
| 2.2 | Tabel `users` | Lengkap dengan PK, UNIQUE, DEFAULT, CHECK | [x] Selesai | ↑ |
| 2.3 | Tabel `lapangan` | Lengkap dengan PK, UNIQUE, DEFAULT, CHECK | [x] Selesai | ↑ |
| 2.4 | Tabel `pemesanan` | Lengkap dengan FK, ENUM, CHECK | [x] Selesai | ↑ |
| 2.5 | Tabel `detail_pemesanan` | Lengkap dengan FK, UNIQUE composite slot, CHECK | [x] Selesai | ↑ |
| 2.6 | Tabel `pembayaran` | Lengkap dengan FK, UNIQUE composite, ENUM, CHECK | [x] Selesai | ↑ |
| 2.7 | Tabel `penomoran` | Composite PK, DEFAULT | [x] Selesai | ↑ |
| 2.8 | Stored Procedure `sp_nomor_berikutnya` | INSERT ON DUPLICATE KEY UPDATE, atomik | [x] Selesai | ↑ |
| 2.9 | Stored Procedure `sp_kedaluwarsakan_pemesanan` | Update status expired | [x] Selesai | ↑ |
| 2.10 | Views (4 views) | `v_jadwal_lapangan`, `v_pendapatan_bulanan`, `v_okupansi_bulanan`, `v_laporan_bulanan` | [x] Selesai | ↑ |
| 2.11 | Sample Data | 2 users (owner, admin hash SHA-256) + 3 lapangan dummy | [x] Selesai | ↑ |

**Checkpoint**: Skrip SQL siap dijalankan oleh pengguna di MySQL server lokal. [x]

---

## Fase 3: NuGet Package

**Tujuan**: Install MySql.Data connector

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 3.1 | Install `MySql.Data` | Terpasang `MySql.Data` v26.10.0 pada `SIPELA.vbproj` | [x] Selesai | `SIPELA/SIPELA.vbproj` |

**Checkpoint**: `dotnet build` berhasil dengan `MySql.Data` terpasang. [x]

---

## Fase 4: Modules — Business Logic Layer

**Tujuan**: Buat 4 module pendukung

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 4.1 | `ModKoneksi.vb` | Connection string, `BukaKoneksi()`, `TestKoneksi()`, error handling koneksi | [x] Selesai | `SIPELA/Modules/ModKoneksi.vb` |
| 4.2 | `ModSesi.vb` | Property: IdUser, Username, NamaLengkap, Role. Method: Logout() | [x] Selesai | `SIPELA/Modules/ModSesi.vb` |
| 4.3 | `ModErrorHandler.vb` | `TampilkanError()`, `TampilkanPeringatan()`, `TampilkanInfo()`, `Konfirmasi()`, logging ke file | [x] Selesai | `SIPELA/Modules/ModErrorHandler.vb` |
| 4.4 | `ModAutoNumber.vb` | `AmbilNomorBerikutnya()` memanggil `sp_nomor_berikutnya`, `BuatKodeOtomatis()` | [x] Selesai | `SIPELA/Modules/ModAutoNumber.vb` |

**Checkpoint**: `dotnet build` berhasil dan modul siap diakses dari seluruh form. [x]

---

## Fase 5: Form Login (`frmLogin`)

**Tujuan**: Form autentikasi dengan SHA-256 hashing dan proteksi brute force

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 5.1 | Designer | Layout 420×345, TextBox user & pass, btnLogin, btnKeluar, lblStatus | [x] Selesai | `SIPELA/Forms/frmLogin.Designer.vb` |
| 5.2 | Logic — Validasi field | Cek username dan password tidak kosong | [x] Selesai | `SIPELA/Forms/frmLogin.vb` |
| 5.3 | Logic — Query user | SELECT by username, cek is_active, cek terkunci_sampai | [x] Selesai | ↑ |
| 5.4 | Logic — Hash & compare | SHA-256 hash password input, bandingkan dengan password_hash di DB | [x] Selesai | ↑ |
| 5.5 | Logic — Gagal login | Increment gagal_login, kunci akun 15 menit jika 5x gagal | [x] Selesai | ↑ |
| 5.6 | Logic — Berhasil | Reset gagal_login, set ModSesi, hide login, show frmMenuUtama | [x] Selesai | ↑ |
| 5.7 | Set sebagai startup form | Diatur di `Application.myapp` dan `Application.Designer.vb` | [x] Selesai | `SIPELA/My Project/Application.Designer.vb` |

**Checkpoint**: Autentikasi dan alur form login berhasil diimplementasikan. [x]

---

## Fase 6: Form Menu Utama (`frmMenuUtama`)

**Tujuan**: Navigasi utama dengan role-based access

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 6.1 | Designer | Layout 720×510, Panel header & footer, 6 tombol menu card, tombol Logout | [x] Selesai | `SIPELA/Forms/frmMenuUtama.Designer.vb` |
| 6.2 | Logic — Load | Tampilkan nama + role dari ModSesi. Enable/disable menu sesuai role | [x] Selesai | `SIPELA/Forms/frmMenuUtama.vb` |
| 6.3 | Logic — Navigasi | Klik Master Lapangan → buka `frmMasterLapangan`. Klik Master Users → buka `frmMasterUsers` | [x] Selesai | ↑ |
| 6.4 | Logic — Future menus | Tombol Pemesanan, Pembayaran, Jadwal, Laporan diberi notifikasi "Fitur Mendatang" | [x] Selesai | ↑ |
| 6.5 | Logic — Logout | Konfirmasi logout → ModSesi.Logout() → close menu → kembali ke `frmLogin` | [x] Selesai | ↑ |

**Checkpoint**: Role-based access control menu utama berhasil diimplementasikan. [x]

---

## Fase 7: Form Master Lapangan (`frmMasterLapangan`)

**Tujuan**: CRUD lapangan dengan DataGridView, ComboBox terhubung database, validasi, soft & hard delete, dan icon tombol

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 7.1 | Designer | Layout 940×600, Panel input kiri + DataGridView kanan, 5 button aksi (Insert, Update, Nonaktifkan, Delete, Clear), search bar | [x] Selesai | `SIPELA/Forms/frmMasterLapangan.Designer.vb` |
| 7.2 | Logic — Load | Muat DataGridView dari MySQL, set default input, format angka mata uang | [x] Selesai | `SIPELA/Forms/frmMasterLapangan.vb` |
| 7.3 | Logic — ComboBox DB | Muat data jenis lantai dinamis dari tabel `jenis_lantai` di database | [x] Selesai | ↑ |
| 7.4 | Logic — Create | Validasi → Cek duplikasi nama → INSERT → refresh DataGridView → reset | [x] Selesai | ↑ |
| 7.5 | Logic — Read | Klik baris di DataGridView → populate data ke form input → masuk mode Ubah | [x] Selesai | ↑ |
| 7.6 | Logic — Update | Validasi → Cek duplikasi jika ganti nama → UPDATE → refresh DataGridView | [x] Selesai | ↑ |
| 7.7 | Logic — Soft Delete | Konfirmasi → UPDATE `is_active = FALSE` → refresh DataGridView | [x] Selesai | ↑ |
| 7.8 | Logic — Hard Delete | Konfirmasi Warning → Cek FK `detail_pemesanan` → DELETE FROM → refresh | [x] Selesai | ↑ |
| 7.9 | Logic — Bersihkan | Reset field → mode Tambah (Insert enabled, Update/Delete/Nonaktifkan disabled) | [x] Selesai | ↑ |
| 7.10 | Logic — Cari | Filter DataView realtime berdasarkan keyword nama/jenis/status | [x] Selesai | ↑ |
| 7.11 | Logic — Validasi | Nama wajib, jenis lantai wajib, harga > 0, nama unik | [x] Selesai | ↑ |
| 7.12 | Logic — Button Styles | Terapkan icon 16x16 PNG, MiddleCenter, MiddleRight, ImageBeforeText via `ModUIHelper` | [x] Selesai | ↑ |
| 7.13 | Logic — Kembali | Tutup dialog form → kembali ke `frmMenuUtama` | [x] Selesai | ↑ |

**Checkpoint**: CRUD Master Lapangan lengkap dengan validasi, ComboBox DB, hard/soft delete, dan DataGridView berhasil dikompilasi. [x]

---

## Fase 8: Form Master Users (`frmMasterUsers`)

**Tujuan**: CRUD user dengan DataGridView, ComboBox role, SHA-256, soft & hard delete, icon tombol, validasi

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 8.1 | Designer | Layout 950×635, GroupBox input user + DataGridView, ComboBox role, 5 button aksi | [x] Selesai | `SIPELA/Forms/frmMasterUsers.Designer.vb` |
| 8.2 | Logic — Load | Muat data pengguna, sembunyikan `password_hash`, isi opsi ComboBox role | [x] Selesai | `SIPELA/Forms/frmMasterUsers.vb` |
| 8.3 | Logic — Create | Validasi → Hash SHA-256 password → INSERT → refresh DataGridView | [x] Selesai | ↑ |
| 8.4 | Logic — Read | Klik baris → populate data (password dikosongkan untuk keamanan) → mode Ubah | [x] Selesai | ↑ |
| 8.5 | Logic — Update | Validasi → Hash password baru jika diisi / pertahankan hash lama jika kosong → UPDATE | [x] Selesai | ↑ |
| 8.6 | Logic — Soft Delete | Cek bukan user yang sedang aktif login → konfirmasi → UPDATE `is_active = FALSE` | [x] Selesai | ↑ |
| 8.7 | Logic — Hard Delete | Cek bukan user aktif → Cek FK pemesanan/pembayaran → DELETE FROM | [x] Selesai | ↑ |
| 8.8 | Logic — Bersihkan | Reset semua field → mode Tambah | [x] Selesai | ↑ |
| 8.9 | Logic — Cari | Filter realtime DataView berdasarkan username, nama lengkap, atau role | [x] Selesai | ↑ |
| 8.10 | Logic — Validasi | Username min 4 karakter & unik, password min 6 karakter, nama lengkap wajib, role wajib | [x] Selesai | ↑ |
| 8.11 | Logic — Button Styles | Terapkan icon 16x16 PNG, MiddleCenter, MiddleRight, ImageBeforeText via `ModUIHelper` | [x] Selesai | ↑ |
| 8.12 | Logic — Kembali | Tutup dialog form → kembali ke menu utama | [x] Selesai | ↑ |
| 8.13 | Logic — Kolom grid | Sembunyikan kolom sensitif `password_hash` dari DataGridView | [x] Selesai | ↑ |

**Checkpoint**: CRUD Master Users lengkap dengan hashing SHA-256, proteksi FK, hard/soft delete, dan icon tombol berhasil dikompilasi. [x]

## Fase 9: Transaksi Pemesanan Lapangan (Master-Detail Form) — Week 11

**Tujuan**: Mengimplementasikan Form Transaksi Pemesanan Master-Detail (`frmPemesanan`) dengan Multi-Slot, Anti Double-Booking, Perhitungan Realtime, Opsi DP Terbayar, dan Full CRUD.

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 9.1 | Designer `frmPemesanan` | 2 Tab (Input Create & Daftar Riwayat Read/Update/Delete), Header GroupBox, Detail Slot GroupBox, DataGridView Detail & Riwayat | [x] Selesai | `SIPELA/Forms/frmPemesanan.Designer.vb` |
| 9.2 | Atomic Auto-Numbering | Support transaksi `MySqlTransaction` dan fallback query di `ModAutoNumber.vb` | [x] Selesai | `SIPELA/Modules/ModAutoNumber.vb` |
| 9.3 | Database ComboBoxes | `cboLapangan` terhubung ke tabel `lapangan` (`is_active = TRUE`), `cboKasir` ke tabel `users` | [x] Selesai | `SIPELA/Forms/frmPemesanan.vb` |
| 9.4 | Jam Operasional 1 Jam | Pilihan 16 slot per jam dari `08:00 - 09:00` s.d. `23:00 - 00:00` | [x] Selesai | ↑ |
| 9.5 | Multi-Slot Basket & Anti Double-Booking | Validasi duplikasi slot di keranjang lokal dan query verifikasi ke database MySQL | [x] Selesai | ↑ |
| 9.6 | Automatic Calculation | Subtotal slot, Grand Total sewa, dan estimasi minimal DP (30%) terhitung otomatis | [x] Selesai | ↑ |
| 9.7 | Create (Simpan Order Atomik) | `conn.BeginTransaction()`, insert `pemesanan`, loop insert `detail_pemesanan`, insert `pembayaran` jika opsi DP dicentang | [x] Selesai | ↑ |
| 9.8 | Read (Riwayat & Detail Slot) | DataGridView riwayat pemesanan terformat rapi + tombol Lihat Detail Slot terpilih | [x] Selesai | ↑ |
| 9.9 | Update (Ubah Status & Pelunasan) | Transisi status 'Menunggu DP' -> 'DP Terbayar' / 'Lunas', catat transaksi pembayaran terkait | [x] Selesai | ↑ |
| 9.10 | Delete (Batalkan Booking) | Soft cancel booking (`status = 'Kedaluwarsa'`), nonaktifkan slot (`aktif = FALSE`) untuk membebaskan jadwal | [x] Selesai | ↑ |
| 9.11 | Button Styling | Seluruh tombol CRUD dilengkapi icon 16x16 px dan layout sesuai standar via `ModUIHelper` | [x] Selesai | ↑ |
| 9.12 | Integrasi Menu Utama | `btnPemesanan` di `frmMenuUtama` terhubung untuk membuka `frmPemesanan` | [x] Selesai | `SIPELA/Forms/frmMenuUtama.vb` |

**Checkpoint**: Form Transaksi Pemesanan Master-Detail berhasil dikompilasi dengan 0 error dan 0 warning. [x]

---

## Fase 10: Laporan Pendapatan, Transaksi, & Okupansi (`frmLaporan`) — Week 12

**Tujuan**: Mengimplementasikan Form Laporan Relasional berbasis data transaksi Week 11 dengan filter dinamis, agregasi metrik, ekspor CSV/Excel, pratinjau cetak / Save to PDF, dan pembatasan akses khusus **Owner**.

| # | Task | Detail | Status | File Output |
|---|------|--------|--------|-------------|
| 10.1 | Designer & Resource `frmLaporan` | 2 Tab (Transaksi & Pendapatan + Ringkasan Bulanan & Okupansi), 5+4 kartu ringkasan agregasi, filter lengkap, `SubType=Form` & `DependentUpon` di `.vbproj` | [x] Selesai | `SIPELA/Forms/frmLaporan.Designer.vb`, `frmLaporan.resx`, `SIPELA.vbproj` |
| 10.2 | Query Relasional & Filter | JOIN 5 tabel (`detail_pemesanan`, `pemesanan`, `lapangan`, `users`, agregasi `pembayaran`) dengan filter Jenis Tanggal, Rentang Tanggal, Lapangan, Status, dan Kata Kunci | [x] Selesai | `SIPELA/Forms/frmLaporan.vb` |
| 10.3 | Agregasi Summary Metrics | Hitung Total Booking, Total Slot Terjual, Grand Total Nilai Sewa, Total Pembayaran Masuk (bebas double-counting), dan Sisa Belum Lunas | [x] Selesai | ↑ |
| 10.4 | Ringkasan Bulanan & Okupansi | Memanfaatkan View `v_laporan_bulanan` (+ fallback query) dengan filter tahun & 4 kartu ringkasan okupansi | [x] Selesai | ↑ |
| 10.5 | Export CSV / Excel | Export UTF-8 BOM CSV (RFC 4180) lengkap dengan header filter & blok ringkasan agregasi untuk Tab 1 dan Tab 2 | [x] Selesai | ↑ |
| 10.6 | Print Preview & Cetak / PDF | `PrintDocument` + `PrintPreviewDialog` untuk 3 mode: Laporan Transaksi (Landscape multi-halaman), Struk/Invoice Booking Terpilih (Portrait dinamis), dan Ringkasan Bulanan | [x] Selesai | ↑ |
| 10.7 | Validasi & Error Handling | Validasi rentang tanggal (`Dari <= Sampai`), helper null-safe (`DBNull`), penanganan hasil kosong tanpa crash, & proteksi IOException saat export | [x] Selesai | ↑ |
| 10.8 | Integrasi Menu Utama (Owner Only) | Unmute `btnLaporan` di `frmMenuUtama`, aktifkan khusus `ModSesi.IsOwner`, plus guard role di `frmLaporan_Load` | [x] Selesai | `SIPELA/Forms/frmMenuUtama.vb`, `frmMenuUtama.Designer.vb` |

**Checkpoint**: Form Laporan Week 12 berhasil dikompilasi dengan 0 error dan 0 warning serta siap dibuka di WinForms Designer Visual Studio. [x]

---

## Dependency Graph

```mermaid
flowchart TD
    P1["[x] Fase 1: Project Setup"] --> P2["[x] Fase 2: Database SQL"]
    P1 --> P3["[x] Fase 3: NuGet MySql.Data"]
    P3 --> P4["[x] Fase 4: Modules"]
    P2 --> P4
    P4 --> P5["[x] Fase 5: frmLogin"]
    P5 --> P6["[x] Fase 6: frmMenuUtama"]
    P6 --> P7["[x] Fase 7: frmMasterLapangan"]
    P6 --> P8["[x] Fase 8: frmMasterUsers"]
    P6 --> P9["[x] Fase 9: frmPemesanan (Master-Detail)"]
    P4 --> P9
    P6 --> P10["[x] Fase 10: frmLaporan (Owner Only)"]
    P9 --> P10
```

---

## File Summary

| # | File | Fase | Status | Deskripsi |
|---|------|------|--------|-----------|
| 1 | `SIPELA/SIPELA.slnx` | 1 | [x] Selesai | Solution file |
| 2 | `SIPELA/SIPELA.vbproj` | 1 | [x] Selesai | Project file (.NET 10 WinForms + explicit Form SubType/DependentUpon) |
| 3 | `Database/arung_futsal.sql` | 2 | [x] Selesai | SQL script lengkap (7 tabel, 2 SP, 4 view, seed data) |
| 4 | `SIPELA/Modules/ModKoneksi.vb` | 4 | [x] Selesai | Database connection module (MySQL) |
| 5 | `SIPELA/Modules/ModSesi.vb` | 4 | [x] Selesai | Session management module (ID, nama, role) |
| 6 | `SIPELA/Modules/ModErrorHandler.vb` | 4 | [x] Selesai | Error handling & file logger module |
| 7 | `SIPELA/Modules/ModAutoNumber.vb` | 4 | [x] Selesai | Auto-numbering module via SP & `MySqlTransaction` |
| 8 | `SIPELA/Forms/frmLogin.vb` | 5 | [x] Selesai | Login form logic (SHA-256 & 5x brute-force lock) |
| 9 | `SIPELA/Forms/frmLogin.Designer.vb` | 5 | [x] Selesai | Login form UI designer |
| 10 | `SIPELA/Forms/frmMenuUtama.vb` | 6 | [x] Selesai | Menu form logic (role-based access: Owner & Admin) |
| 11 | `SIPELA/Forms/frmMenuUtama.Designer.vb` | 6 | [x] Selesai | Menu form UI designer |
| 12 | `SIPELA/Forms/frmMasterLapangan.vb` | 7 | [x] Selesai | Master lapangan CRUD logic & search |
| 13 | `SIPELA/Forms/frmMasterLapangan.Designer.vb` | 7 | [x] Selesai | Master lapangan UI designer |
| 14 | `SIPELA/Forms/frmMasterUsers.vb` | 8 | [x] Selesai | Master users CRUD logic, ComboBox role, & search |
| 15 | `SIPELA/Forms/frmMasterUsers.Designer.vb` | 8 | [x] Selesai | Master users UI designer |
| 16 | `SIPELA/My Project/Application.Designer.vb` | 5 | [x] Selesai | Startup form diarahkan ke `frmLogin` |
| 17 | `Database/migration_jenis_lantai.sql` | 2 | [x] Selesai | Skrip migrasi tabel master `jenis_lantai` |
| 18 | `SIPELA/Modules/ModUIHelper.vb` | 4 | [x] Selesai | Helper style tombol (icon 16×16, alignment) |
| 19 | `SIPELA/Resources/Icons/` | 4 | [x] Selesai | Icon PNG 16×16 px (insert, update, delete, clear, deactivate) |
| 20 | `SIPELA/Forms/frmPemesanan.vb` | 9 | [x] Selesai | Form transaksi Master-Detail logic, multi-slot & anti double-booking |
| 21 | `SIPELA/Forms/frmPemesanan.Designer.vb` | 9 | [x] Selesai | Form transaksi Master-Detail UI designer (2 tab: Input & Riwayat) |
| 22 | `SIPELA/Forms/frmLaporan.vb` | 10 | [x] Selesai | Form laporan relasional, agregasi, export CSV/Excel, & cetak PDF/Struk |
| 23 | `SIPELA/Forms/frmLaporan.Designer.vb` | 10 | [x] Selesai | Form laporan UI designer (2 tab: Transaksi & Ringkasan Bulanan) |
| 24 | `SIPELA/Forms/frmLaporan.resx` | 10 | [x] Selesai | Resource file untuk `frmLaporan` (Visual Studio Designer support) |
