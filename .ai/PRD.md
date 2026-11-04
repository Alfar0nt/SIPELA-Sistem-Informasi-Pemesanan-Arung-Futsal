# PRD — SIPELA (Sistem Pemesanan Lapangan Arung Futsal)

> **Versi**: 1.0 — Week 10 Deliverable  
> **Tanggal**: 4 November 2026  
> **Mata Kuliah**: Pemrograman Desktop — Semester 3  
> **Dosen**: Tri Luhur Indayanti Sugata, S.ST, M.IM.  
> **Kelompok International**:
> 1. Helder Abel Freitas (25082010277)
> 2. Ifaliantsoa Shearia Yiska F. (25082010278)
> 3. Dhiaurrahman Rabbani Harianto (25082010042)

---

## 1. Latar Belakang

Arung Futsal adalah usaha penyewaan lapangan futsal yang beroperasi setiap hari pukul 08.00–00.00 dengan durasi sewa per slot 1 jam. Proses pemesanan saat ini 100% manual (WhatsApp + buku fisik), menyebabkan:

- Nama pemesan hilang dan jadwal bentrok (double booking)
- Pembayaran DP/pelunasan tidak tercatat terstruktur
- Pemilik sulit memantau pendapatan dan okupansi

**SIPELA** dirancang sebagai aplikasi desktop VB.NET Windows Forms untuk memusatkan pencatatan jadwal, pemesanan, pembayaran, dan pelaporan.

---

## 2. Scope Week 10

> [!IMPORTANT]
> Dokumen ini hanya mencakup **deliverable Week 10** dari keseluruhan rancangan SIPELA.

### 2.1 Yang Dikerjakan (In Scope)

| # | Deliverable | Deskripsi |
|---|-------------|-----------|
| 1 | **Database Design (ERD)** | Finalisasi ERD dengan tabel, PK, FK, dan relasi |
| 2 | **Database Implementation** | Skrip SQL MySQL (`arung_futsal.sql`) lengkap dengan tabel, constraint, stored procedure, view, dan sample data |
| 3 | **Database Connection** | Modul koneksi reusable (`ModKoneksi.vb`) dengan error handling |
| 4 | **Master Data Form 1 — Lapangan** | `frmMasterLapangan`: CRUD lapangan (nama, jenis lantai, harga per jam), DataGridView, auto-numbering, validasi input |
| 5 | **Master Data Form 2 — Users** | `frmMasterUsers`: CRUD akun pengguna (username, password, nama lengkap, role), DataGridView, auto-numbering, validasi, ComboBox role |
| 6 | **Form Login** | `frmLogin`: autentikasi username + password hash SHA-256, routing berdasarkan role |
| 7 | **Menu Utama** | `frmMenuUtama`: navigasi menu berdasarkan role (Admin/Owner) |
| 8 | **Source Code** | Project VB.NET Windows Forms (.NET 10) |

### 2.2 Yang TIDAK Dikerjakan (Out of Scope Week 10)

- Form Pemesanan (`frmPemesanan`)
- Form Pembayaran (`frmPembayaran`)
- Form Kalender Jadwal (`frmJadwal`)
- Form Laporan (`frmLaporan`)
- RDLC Report
- Aplikasi mobile
- Payment Gateway
- Ekspor Excel

### 2.3 Catatan Khusus: `frmMasterUsers`

Di laporan asli, manajemen akun pengguna disebutkan "akun dibuat langsung di database". Untuk memenuhi requirement Week 10 (minimal 2 master data form), kita menambahkan `frmMasterUsers` sebagai form master kedua. Form ini:

- Hanya diakses oleh **Owner**
- CRUD: tambah, ubah, nonaktifkan akun (bukan hapus, untuk menjaga integritas data)
- Menggunakan **ComboBox** untuk pilihan role (Admin/Owner) — memenuhi requirement assignment
- Password disimpan sebagai hash **SHA-256**
- Auto-numbering untuk user ID

> [!NOTE]
> Pada rancangan SIPELA final, fitur ini mungkin dihapus atau diubah. Untuk sekarang, ini berfungsi sebagai deliverable akademik Week 10.

---

## 3. Aktor / Pengguna

| Aktor | Peran pada Week 10 |
|-------|---------------------|
| **Owner** | Login; kelola master lapangan (CRUD); kelola master users (CRUD); navigasi menu |
| **Admin** | Login; lihat data lapangan (read-only atau sesuai keputusan); navigasi menu |

---

## 4. Aturan Bisnis (Week 10)

| Aturan | Detail |
|--------|--------|
| Jam operasional | 08:00–00:00 (16 slot per lapangan per hari) |
| Durasi slot | 1 jam |
| Harga | Per jam, dicatat per lapangan |
| Password | SHA-256 hash, bukan plaintext |
| Login lock | Akun dikunci sementara setelah 5x gagal login berturut-turut |
| Soft delete | Lapangan dan Users dinonaktifkan (`is_active = FALSE`), bukan dihapus |
| Auto-numbering | ID otomatis untuk kode yang membutuhkan format khusus |

---

## 5. Keberhasilan (Success Criteria Week 10)

- [ ] Database MySQL `arung_futsal` berhasil dibuat dan berisi sample data
- [ ] Koneksi VB.NET ke MySQL berhasil, error handling berjalan
- [ ] `frmMasterLapangan` — CRUD lengkap, validasi, auto-number, DataGridView
- [ ] `frmMasterUsers` — CRUD lengkap, validasi, ComboBox role, DataGridView
- [ ] `frmLogin` — autentikasi berhasil, routing ke menu sesuai role
- [ ] `frmMenuUtama` — menu tampil sesuai role
- [ ] Semua form bisa di-demo dalam video

