# PRD — SIPELA (Sistem Pemesanan Lapangan Arung Futsal)

> **Versi**: 1.2 — Week 10, Week 11, & Week 12 Deliverable  
> **Tanggal**: 18 November 2026  
> **Mata Kuliah**: Pemrograman Desktop — Semester 3  
> **Dosen**: Tri Luhur Indayanti Sugata, S.ST, M.IM.  
> **Kelompok International**:
> 1. Dhiaurrahman Rabbani Harianto (25082010042)
> 2. Helder Abel Freitas (25082010277)
> 3. Ifaliantsoa Shearia Yiska F. (25082010278)

---

## 1. Latar Belakang

Arung Futsal adalah usaha penyewaan lapangan futsal yang beroperasi setiap hari pukul 08.00–00.00 dengan durasi sewa per slot 1 jam. Proses pemesanan sebelumnya 100% manual (WhatsApp + buku fisik), menyebabkan:

- Nama pemesan hilang dan jadwal bentrok (*double booking*)
- Pembayaran DP/pelunasan tidak tercatat terstruktur
- Pemilik sulit memantau pendapatan, tagihan belum lunas, dan tingkat okupansi lapangan

**SIPELA** dirancang sebagai aplikasi desktop VB.NET Windows Forms (.NET 10) + MySQL untuk memusatkan pencatatan master data, pemesanan multi-slot, pembayaran DP/pelunasan, dan pelaporan lengkap.

---

## 2. Scope Deliverable (Week 10 – Week 12)

### 2.1 Yang Sudah Diimplementasikan (In Scope)

| Tahap | Deliverable | Deskripsi |
|---|---|---|
| **Week 10** | **Database Design & Implementation** | Skrip SQL MySQL (`arung_futsal.sql` & `migration_jenis_lantai.sql`) lengkap dengan 7 tabel, PK/FK, constraint, 2 stored procedure, 4 view, dan seed data. |
| **Week 10** | **Modul Inti & Koneksi Reusable** | `ModKoneksi.vb`, `ModSesi.vb`, `ModErrorHandler.vb`, `ModAutoNumber.vb`, dan `ModUIHelper.vb` (standar tombol icon 16×16 px). |
| **Week 10** | **Autentikasi & Menu Utama** | `frmLogin` (SHA-256 + brute-force lock 5×/15 menit) dan `frmMenuUtama` (Role-Based Access Control). |
| **Week 10** | **Master Data Form 1 & 2** | `frmMasterLapangan` (CRUD + ComboBox DB `jenis_lantai` + Soft/Hard Delete proteksi FK) & `frmMasterUsers` (CRUD + SHA-256 + proteksi akun aktif & FK). |
| **Week 11** | **Form Transaksi Master-Detail (`frmPemesanan`)** | 2 Tab (Input Pemesanan Multi-Slot & Riwayat Manajemen CRUD), ComboBox DB (`lapangan` & `users`), penomoran otomatis atomik (`BKG-YYYYMMDD-XXXX` & `PAY-YYYYMMDD-XXXX`), validasi anti *double-booking*, perhitungan otomatis Grand Total & DP 30%, opsi langsung catat DP, serta penyimpanan atomik via `MySqlTransaction`. |
| **Week 12** | **Form Laporan Pendapatan & Okupansi (`frmLaporan`)** | 2 Tab (Tab 1: Laporan Relasional Transaksi & Pendapatan terfilter + 5 kartu agregasi + Cetak Struk/Invoice Booking; Tab 2: Ringkasan Bulanan & Okupansi dari View `v_laporan_bulanan`), Ekspor CSV/Excel (UTF-8 BOM), dan Pratinjau Cetak / Save to PDF (`PrintDocument`). Khusus **Owner**. |

### 2.2 Yang Belum Diimplementasikan (Final Project / Future)

- Form Pembayaran Terpisah (`frmPembayaran`) — pencatatan DP & pelunasan saat ini sudah terintegrasi penuh di `frmPemesanan`.
- Form Kalender Jadwal Visual (`frmJadwal`).
- Aplikasi mobile & integrasi Payment Gateway.

---

## 3. Aktor / Pengguna & Matriks Hak Akses

| Fitur / Form | Owner | Admin | Keterangan |
|---|:---:|:---:|---|
| `frmLogin` | ✅ | ✅ | Autentikasi SHA-256 & brute-force protection |
| `frmMasterLapangan` | ✅ | ✅ | Manajemen data lapangan & tarif sewa |
| `frmMasterUsers` | ✅ | ❌ | Khusus Owner (manajemen akun kasir/owner) |
| `frmPemesanan` | ✅ | ✅ | Transaksi pemesanan multi-slot, DP, pelunasan, pembatalan |
| `frmLaporan` | ✅ | ❌ | **Khusus Owner** (Laporan transaksi, pendapatan, okupansi, ekspor & cetak) |
| Logout | ✅ | ✅ | Bersihkan sesi & kembali ke `frmLogin` |

---

## 4. Aturan Bisnis Utama

| Aturan | Detail |
|---|---|
| Jam operasional | 08:00–00:00 (16 slot per lapangan per hari, durasi 1 jam/slot) |
| Anti double-booking | Validasi di keranjang lokal + query aktif + `UNIQUE KEY uq_slot_aktif` di MySQL |
| Minimal DP | 30% dari total nilai sewa; dapat dicatat langsung saat membuat order atau menyusul |
| Penomoran otomatis | `BKG-YYYYMMDD-XXXX` (booking) dan `PAY-YYYYMMDD-XXXX` (pembayaran) via `sp_nomor_berikutnya` |
| Keamanan akun | Password hash SHA-256; lock 15 menit setelah 5× gagal login berturut-turut |
| Integritas pelaporan | Agregasi bebas *double-counting* pada transaksi multi-slot, aman dari `DBNull`, dan validasi rentang tanggal |

---

## 5. Kriteria Keberhasilan (Week 10 – Week 12)

- [x] Database MySQL `arung_futsal` + seed data + views + stored procedures
- [x] Koneksi VB.NET ke MySQL reusable + error handling
- [x] `frmLogin`, `frmMenuUtama`, `frmMasterLapangan`, `frmMasterUsers` (Week 10)
- [x] `frmPemesanan` Master-Detail CRUD, multi-slot, anti double-booking, transaksi atomik (Week 11)
- [x] `frmLaporan` relasional terfilter, agregasi metrik, ekspor CSV/Excel, Print Preview / PDF + Struk Booking, khusus Owner (Week 12)
- [x] Semua form kompatibel dengan Visual Studio WinForms Designer & lolos `dotnet build` dengan 0 error, 0 warning
