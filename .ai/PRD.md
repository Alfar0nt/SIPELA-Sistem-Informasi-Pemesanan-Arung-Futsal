# PRD — Product Requirements Document: SIPELA (Sistem Informasi Pemesanan Arung Futsal)

> **Versi**: 2.0 — Full Operational System Scope  
> **Tanggal**: 4 November 2026  
> **Mata Kuliah**: Pemrograman Desktop — Semester 3 (UPN "Veteran" Jawa Timur)  
> **Status**: Perencanaan Sistem Operasional Penuh

---

## 1. Latar Belakang & Masalah Bisnis

Arung Futsal adalah unit bisnis penyewaan lapangan futsal yang beroperasi setiap hari dari pukul **08.00 hingga 24.00** (total 16 slot waktu per lapangan per hari). Berdasarkan observasi lapangan dan *data-driven research* (ekstraksi ulasan Google Maps Arung Futsal):
- **Masalah Pencatatan Manual**: Proses pemesanan yang sebelumnya bertumpu pada chat WhatsApp dan pencatatan buku fisik kerap menimbulkan kesalahan manusia (*human error*), seperti hilangnya nama pemesan dan terjadinya tabrakan jadwal (*double booking*).
- **Ketidakpastian Finansial**: Uang Muka (DP) dan pelunasan tidak tercatat secara terpadu, menyulitkan kasir untuk melacak status piutang sewa.
- **Kesulitan Rekapitulasi Pemilik**: Pemilik (*Owner*) kesulitan memantau pergerakan omzet harian, pendapatan bulanan, dan tingkat utilisasi (*okupansi*) lapangan secara *real-time*.

**SIPELA** hadir sebagai sistem operasional desktop berbasis **VB.NET Windows Forms (.NET 10)** dan **MySQL** yang memusatkan seluruh rantai operasional harian kasir dan manajemen pemilik.

---

## 2. Persona Pengguna

### Persona 1: Pak Faiz (Pemilik Bisnis / Owner)
- **Profil**: Pemilik Arung Futsal, memiliki wewenang tertinggi.
- **Kebutuhan**: Memantau ringkasan pendapatan bulanan, analisis pertumbuhan Month-over-Month (MoM), tingkat okupansi lapangan, serta mengontrol tarif sewa lapangan dan akun staf operasional.
- **Akses**: Penuh ke seluruh modul (Master Lapangan, Master Users, Jadwal, Laporan & Analitik).

### Persona 2: Admin / Kasir Operasional
- **Profil**: Staf yang bertugas di meja operasional lapangan.
- **Kebutuhan**: Antarmuka kasir yang cepat (*tactile & responsive*), kemudahan memeriksa ketersediaan slot kosong, mencatat pemesanan walk-in/telepon tanpa risiko bentrok, memproses pembayaran DP/pelunasan, dan mencetak struk sewa resmi.
- **Akses**: Transaksi Pemesanan, Kasir Pembayaran, Kalender Jadwal, dan Cetak Nota. Dibatasi dari pengubahan akun staf lain dan laporan laba bersih.

### Persona 3: Pelanggan (Mas Migon / Tim Futsal)
- **Profil**: Komunitas futsal yang menyewa lapangan secara berkala.
- **Kebutuhan**: Kepastian slot waktu yang transparan, bukti tanda terima pembayaran DP/lunas resmi, serta kepastian bahwa lapangan tidak akan diserobot tim lain.

---

## 3. Ruang Lingkup Sistem Operasional Penuh

### 3.1 Fitur Inti yang Diimplementasikan (In-Scope)

| Modul | Deskripsi Fungsional | Aktor |
|-------|----------------------|-------|
| **Autentikasi & Sesi** | Login terenkripsi SHA-256, deteksi brute-force (kunci akun 15 menit jika 5x salah), dan hak akses berbasis peran (*Role-Based Access Control*). | Admin, Owner |
| **Master Lapangan** | Pengelolaan data lapangan (nama, jenis lantai: vinyl/rumput sintetis, tarif per jam), validasi keunikan, dan soft-delete. | Owner |
| **Master Users** | Pengelolaan akun staf kasir dan pemilik dengan ComboBox peran serta proteksi penghapusan diri sendiri. | Owner |
| **Pemesanan Lapangan** | Input data pemesan, penomoran kode booking otomatis (`BKG-YYYYMMDD-XXXX`), pemilihan slot visual 08.00–24.00, kalkulasi total dan DP minimal 30%, serta penegakan anti-double booking. | Admin, Owner |
| **Kasir & Pembayaran** | Pencarian tagihan booking, pembayaran DP & Pelunasan, kalkulasi uang kembali, penomoran transaksi (`PAY-YYYYMMDD-XXXX`), dan cetak nota fisik. | Admin, Owner |
| **Kalender Matriks Jadwal** | Tampilan visual grid ketersediaan seluruh lapangan per jam dengan indikator warna tegas (Tersedia, Terisi, Menunggu DP). | Admin, Owner |
| **Laporan & Analitik** | Dasbor pendapatan bulanan, grafik okupansi lapangan, perbandingan MoM, dan ekspor data tabular ke spreadsheet (CSV/Excel). | Owner |
| **Auto-Expiration Engine** | Routine otomatis untuk mendeteksi dan membatalkan pemesanan yang tidak dibayar dalam batas waktu 15 menit. | Sistem |

### 3.2 Roadmap Masa Depan (Post-MVP)
- **Modul Open Sparring (`frmOpenSparring`)**:
  - DFD Level 0 Proses 4.0 mengidentifikasi kebutuhan pencarian lawan tanding antar tim futsal. Fitur ini dicatat untuk fase lanjutan setelah sistem kasir dan pencatatan operasional utama teruji secara stabil.

---

## 4. Aturan Bisnis (Business Rules)

1. **Jam Operasional**: Lapangan beroperasi pukul 08.00 hingga 24.00 (slot dimulai dari jam 08.00, 09.00, ..., 23.00). Slot di luar jam ini tidak dapat dipesan.
2. **Durasi Slot**: Durasi minimum sewa adalah 1 jam per slot, dengan kelipatan slot penuh per jam.
3. **Ketentuan Uang Muka (DP)**:
   - DP minimal adalah **30%** dari total biaya sewa lapangan.
   - Waktu tunggu pembayaran DP maksimal adalah **15 menit** sejak transaksi pemesanan dibuat. Jika melewati batas, pemesanan dinyatakan `Kedaluwarsa` dan slot dilepas kembali.
4. **Anti-Double Booking**: Satu slot pada satu lapangan di satu tanggal hanya boleh dialokasikan ke tepat satu pemesanan aktif (ditegakkan via database unique constraint `uq_slot_aktif`).
5. **Pelunasan**: Pelunasan sisa 70% dapat dilakukan sebelum waktu kickoff pemesanan.
6. **Integritas Transaksi**: Pemesanan yang telah memiliki catatan pembayaran tidak dapat dihapus sembarangan untuk menjaga keabsahan rekap audit keuangan.

---

## 5. Kebutuhan Non-Fungsional (NFR)

- **Keamanan (Security)**: Password disimpan dalam bentuk hash SHA-256. Komunikasi database menggunakan *parameterized queries* untuk mencegah ancaman SQL Injection.
- **Responsivitas UI (Performance)**: Antarmuka merespons klik dan peralihan tab dalam waktu di bawah 1 detik di sistem operasi Windows 11.
- **Kenyamanan Visual (Ergonomics)**: Mengusung tema visual **Tactile Claymorphism + Neo-Brutalism** dengan kontras tinggi (Cream `#FDFBF7` dan Slate `#2D334A`), tombol taktil, serta penanda warna status yang intuitif bagi operator kasir.
- **Keandalan Data (Reliability)**: 0 toleransi double-booking berkat transaksi atomik pada level database engine MySQL InnoDB.
