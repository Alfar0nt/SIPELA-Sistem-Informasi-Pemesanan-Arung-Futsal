# APP-FLOW — Application Flow

> **Versi**: 1.2 — Week 10, Week 11, & Week 12 Deliverable  
> **Tanggal**: 18 November 2026

---

## 1. Alur Utama Aplikasi (Week 10 – Week 12)

```mermaid
flowchart TD
    A["App Start"] --> B["frmLogin"]
    B --> C{"Login berhasil?"}
    C -->|Tidak| D["Tampilkan error / Lock akun"]
    D --> B
    C -->|Ya - Owner| E["frmMenuUtama (Owner)"]
    C -->|Ya - Admin| F["frmMenuUtama (Admin)"]

    E --> G["frmMasterLapangan"]
    E --> H["frmMasterUsers"]
    E --> I["frmPemesanan"]
    E --> J["frmLaporan (Khusus Owner)"]
    E --> K["Logout → frmLogin"]

    F --> L["frmMasterLapangan"]
    F --> M["frmPemesanan"]
    F --> N["Logout → frmLogin"]
```

---

## 2. Alur Login (`frmLogin`)

```mermaid
flowchart TD
    A["User input username + password"] --> B{"Field kosong?"}
    B -->|Ya| C["MessageBox: field wajib diisi"]
    C --> A
    B -->|Tidak| D["Query user by username"]
    D --> E{"User ditemukan?"}
    E -->|Tidak| F["MessageBox: username/password salah"]
    F --> A
    E -->|Ya| G{"Akun aktif?"}
    G -->|Tidak| H["MessageBox: akun nonaktif"]
    H --> A
    G -->|Ya| I{"Akun terkunci?"}
    I -->|Ya, belum expired| J["MessageBox: akun terkunci"]
    J --> A
    I -->|Tidak / sudah expired| K["Hash SHA-256 & verifikasi"]
    K --> L{"Hash cocok?"}
    L -->|Tidak| M["Increment gagal_login (lock 15 menit jika >= 5)"]
    M --> A
    L -->|Ya| N["Reset gagal_login, simpan ModSesi, buka frmMenuUtama"]
```

---

## 3. Alur Menu Utama (`frmMenuUtama`)

### Matriks Hak Akses Menu

| Menu Item | Owner | Admin | Form Target | Status Implementasi |
|---|:---:|:---:|---|---|
| Master Lapangan | ✅ Enabled | ✅ Enabled | `frmMasterLapangan` | ✅ Selesai (Week 10) |
| Master Users | ✅ Enabled | ❌ Disabled | `frmMasterUsers` | ✅ Selesai (Week 10) |
| Transaksi Pemesanan | ✅ Enabled | ✅ Enabled | `frmPemesanan` | ✅ Selesai (Week 11) |
| Laporan Pendapatan & Okupansi | ✅ Enabled | ❌ Disabled | `frmLaporan` | ✅ Selesai (Week 12) |
| Transaksi Pembayaran (Terpisah) | ⏳ Placeholder | ⏳ Placeholder | — | Terintegrasi di `frmPemesanan` |
| Kalender Jadwal Lapangan | ⏳ Placeholder | ⏳ Placeholder | — | Final Project |
| Keluar / Logout | ✅ Enabled | ✅ Enabled | → `frmLogin` | ✅ Selesai (Week 10) |

---

## 4. Alur Master Data (`frmMasterLapangan` & `frmMasterUsers`)

- **`frmMasterLapangan`**: Memuat ComboBox `jenis_lantai` dari DB → CRUD lengkap (Insert, Update, Soft Delete / Nonaktifkan, Hard Delete dengan cek FK `detail_pemesanan`, Clear, pencarian realtime).
- **`frmMasterUsers`**: Khusus Owner → CRUD akun dengan hash SHA-256, proteksi hapus akun yang sedang login, proteksi FK transaksi, sensor kolom `password_hash`, dan pencarian realtime.

---

## 5. Alur Transaksi Master-Detail (`frmPemesanan` — Week 11)

```mermaid
flowchart TD
    A["Buka frmPemesanan"] --> B["Tab 1: Input Pemesanan Baru"]
    A --> C["Tab 2: Daftar & Riwayat Pemesanan"]

    B --> B1["Auto-number BKG + Muat cboKasir & cboLapangan"]
    B1 --> B2["Pilih Lapangan, Tanggal, Jam (08:00-00:00)"]
    B2 --> B3{"Cek Anti Double-Booking (Keranjang & DB)"}
    B3 -->|Bentrok| B4["Peringatan: Slot Tidak Tersedia"]
    B3 -->|Tersedia| B5["Tambah ke Keranjang + Hitung Grand Total & DP 30%"]
    B5 --> B6["Simpan Order (MySqlTransaction)"]
    B6 --> B7["Insert pemesanan + detail_pemesanan + pembayaran (jika DP dicentang)"]
    B7 --> B8["Commit (atau Rollback jika gagal)"]

    C --> C1["Read & Filter Riwayat"]
    C1 --> C2["Lihat Detail Slot"]
    C1 --> C3["Ubah Status / Pelunasan (Update + Insert pembayaran)"]
    C1 --> C4["Batalkan Booking (Status Kedaluwarsa + aktif = FALSE)"]
```

---

## 6. Alur Pelaporan Pendapatan & Okupansi (`frmLaporan` — Week 12)

```mermaid
flowchart TD
    A["Owner Klik Menu Laporan"] --> B{"ModSesi.IsOwner?"}
    B -->|Tidak| C["Peringatan Akses Ditolak & Tutup Form"]
    B -->|Ya| D["Buka frmLaporan"]

    D --> T1["Tab 1: Laporan Transaksi & Pendapatan"]
    D --> T2["Tab 2: Ringkasan Bulanan & Okupansi"]

    T1 --> F1["Filter: Jenis Tanggal, Dari-Sampai, Lapangan, Status, Cari"]
    F1 --> V1{"dtpDari <= dtpSampai?"}
    V1 -->|Tidak| E1["Peringatan Validasi Rentang Tanggal"]
    V1 -->|Ya| Q1["Query Relasional 5 Tabel + Hitung 5 Kartu Agregasi"]
    Q1 --> R1{"Data > 0 baris?"}
    R1 -->|Tidak| Z1["Info Data Kosong & Disable Tombol Export/Cetak"]
    R1 -->|Ya| A1["Tampilkan DataGridView & Aktifkan Aksi"]
    A1 --> EX1["Export CSV / Excel (UTF-8 BOM)"]
    A1 --> PR1["Print Preview / Save PDF (Laporan Landscape Multi-Halaman)"]
    A1 --> ST1["Print Preview / Save PDF (Struk / Invoice Booking Terpilih)"]

    T2 --> F2["Filter Tahun → Query View v_laporan_bulanan (+ Fallback)"]
    F2 --> A2["Tampilkan DataGridView + 4 Kartu Ringkasan Bulanan"]
    A2 --> EX2["Export CSV Bulanan"]
    A2 --> PR2["Print Preview / Save PDF Ringkasan Bulanan"]
```
