# DESIGN — UI Design Specification (Tactile Claymorphism + Neo-Brutalism)

> **Versi**: 2.1 — Full Operational System SIPELA  
> **Tanggal**: 5 November 2026  
> **Style**: Tactile Claymorphism + Neo-Brutalism (Adapted for VB.NET Windows Forms)  
> **Status**: Fase Operasional Inti Selesai (Fase 9 s.d. 15)

---

## 1. Filosofi & Prinsip Desain

Aplikasi desktop **SIPELA** mengadaptasi estetika modern **Tactile Claymorphism + Neo-Brutalism** ke dalam ekosistem **Windows Forms (.NET 10)**. Tujuannya adalah menciptakan pengalaman antarmuka kasir/admin yang playful, sangat tegas, mudah dibaca (*high legibility*), dan terasa memiliki kedalaman fisik (*tactile depth*).

### Pilar Desain:
1. **Bold Ink & Crisp Outlines**: Setiap kartu (*card*), tombol (*button*), badge, dan panel memiliki border tebal solid berukuran 2px - 2.5px dengan warna Dark Slate Ink (`#2D334A`).
2. **Solid Offset Shadows (Neo-Brutalism)**: Bayangan bukan blur gradien biasa, melainkan bayangan solid tanpa blur dengan offset ke bawah/kanan (efek stiker/blok fisik).
   - Card Shadow: `4px` hingga `6px` offset solid (`#2D334A`)
   - Button Shadow: `3px` hingga `4px` offset solid (`#2D334A`)
3. **Tactile Micro-Interactions**: Kontrol merespons interaksi pengguna secara taktil.
   - **Hover (MouseEnter)**: Tombol terangkat sedikit (-2px) atau bayangan menebal.
   - **Click/Pressed (MouseDown)**: Tombol tertekan masuk (+2px ke bawah/kanan) dan bayangan offset mengecil menjadi 0px, memberikan umpan balik mekanis nyata.
4. **Soft Pastel Highlights (Claymorphism)**: Dipadukan dengan aksen warna pastel yang lembut (*Mint, Sky Blue, Coral, Lavender*) untuk membedakan kategori dan status ketersediaan lapangan.

---

## 2. Palet Warna Resmi

| Elemen / Token | Nama Warna | Hex Code | Nilai RGB / .NET Color | Penggunaan |
|----------------|------------|----------|------------------------|------------|
| **Canvas** | Warm Cream | `#FDFBF7` | `Color.FromArgb(253, 251, 247)` | Background utama form & kanvas aplikasi |
| **Ink / Border** | Crisp Dark Slate | `#2D334A` | `Color.FromArgb(45, 51, 74)` | Teks utama, garis border panel, tombol outline |
| **Card Surface** | Pure White | `#FFFFFF` | `Color.White` | Permukaan kartu input, container data |
| **Primary Accent** | Mint Green | `#25C16F` | `Color.FromArgb(37, 193, 111)` | Tombol utama (Simpan/Selesai), slot Tersedia, status Lunas |
| **Secondary Accent** | Sky Blue | `#AED4E6` | `Color.FromArgb(174, 212, 230)` | Tombol navigasi, filter pill, slot Terpilih |
| **Alert / Warning** | Coral | `#FFB5B5` | `Color.FromArgb(255, 181, 181)` | Tombol bahaya/batal, slot Terisi/Booking, peringatan DP |
| **Neutral Accent** | Lavender | `#D8D4F2` | `Color.FromArgb(216, 212, 242)` | Kartu info statistik, baris tabel selang-seling, badge netral |
| **Muted Text** | Slate Muted | `#7A829E` | `Color.FromArgb(122, 130, 158)` | Placeholder, sub-judul, teks bantuan (*hint*) |

---

## 3. Tipografi

- **Font Keluarga Utama**: `Segoe UI` (default bawaan Windows 11) atau `Plus Jakarta Sans` / `Fredoka` jika terinstal di sistem.
- **Hierarki Font**:
  - **Judul Besar / Header Form**: 16pt – 18pt, Bold (`#2D334A`)
  - **Judul Seksi / Subheader Card**: 11pt – 12pt, Bold (`#2D334A`)
  - **Teks Tombol & Badge**: 9.5pt – 10pt, Bold
  - **Body Teks & Input Field**: 9.5pt, Regular (`#2D334A`)
  - **Label Meta & Hint**: 8.5pt, Regular (`#7A829E`)

---

## 4. Mekanika Kontrol Windows Forms (Tactile Neo-Brutalism)

Untuk mencapai tampilan Neo-Brutalism di Windows Forms tanpa library pihak ketiga yang berat, digunakan standar properti bawaan serta modul pembantu `ModUIHelper.vb`:

### 4.1 Tombol (Button Mechanics)
```vb
btn.FlatStyle = FlatStyle.Flat
btn.FlatAppearance.BorderSize = 2
btn.FlatAppearance.BorderColor = Color.FromArgb(45, 51, 74) ' #2D334A
btn.Cursor = Cursors.Hand
btn.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
```
- **Micro-interaction Tombol**:
  - `MouseDown`: `btn.Location = New Point(btn.Left + 2, btn.Top + 2)`
  - `MouseUp`: `btn.Location = New Point(btn.Left - 2, btn.Top - 2)`

### 4.2 Panel Kartu (Card Panels)
- Container berupa `Panel` berlatar belakang `Color.White`.
- Dikelilingi panel bayangan belakang (`pnlShadow`) berwarna `#2D334A` berjarak offset `4px` di kanan-bawah kartu, atau digambar menggunakan event `Paint`:
```vb
Private Sub PanelCard_Paint(sender As Object, e As PaintEventArgs)
    Dim rect As Rectangle = Me.ClientRectangle
    rect.Width -= 3
    rect.Height -= 3
    Using p As New Pen(Color.FromArgb(45, 51, 74), 2.5!)
        e.Graphics.DrawRectangle(p, rect)
    End Using
End Sub
```

### 4.3 DataGridView Neo-Brutalist Styling
| Properti | Nilai | Penjelasan Visual |
|----------|-------|-------------------|
| `BackgroundColor` | `#FDFBF7` | Sesuai kanvas cream |
| `BorderStyle` | `BorderStyle.FixedSingle` | Border luar rapi |
| `GridColor` | `#2D334A` | Garis kisi tegas |
| `EnableHeadersVisualStyles` | `False` | Mengaktifkan warna header kustom |
| `ColumnHeadersDefaultCellStyle.BackColor` | `#2D334A` | Header tabel slate gelap |
| `ColumnHeadersDefaultCellStyle.ForeColor` | `#FFFFFF` | Teks header putih tebal |
| `ColumnHeadersDefaultCellStyle.Font` | `Segoe UI, 9.5pt, Bold` | Tegas dan terbaca |
| `ColumnHeadersHeight` | `38` | Padding header lapang |
| `DefaultCellStyle.BackColor` | `#FFFFFF` | Baris utama putih bersih |
| `AlternatingRowsDefaultCellStyle.BackColor` | `#F5F3FF` atau `#D8D4F2` (soft) | Baris selang-seling pastel lavender lembut |
| `DefaultCellStyle.SelectionBackColor` | `#AED4E6` | Baris terpilih warna Sky Blue |
| `DefaultCellStyle.SelectionForeColor` | `#2D334A` | Teks baris terpilih tetap kontras hitam |
| `RowTemplate.Height` | `32` | Tinggi baris nyaman untuk disentuh/diklik |

---

## 5. Spesifikasi Detail Form Sistem Operasional

### 5.1 `frmLogin` (Pintu Masuk Terproteksi)
- **Ukuran**: 440 × 480 px, `StartPosition = CenterScreen`, `FormBorderStyle = FixedDialog`
- **Background**: Warm Cream (`#FDFBF7`)
- **Struktur Kartu Utama**:
  - Kartu tengah putih `rounded/border 2.5px #2D334A` dengan bayangan offset 6px.
  - Header: Pill Badge Mint (`#25C16F`) dengan ikon bola futsal + teks tebal **"SIPELA ARUNG FUTSAL"**.
  - Subheader: *"Sistem Informasi Operasional & Pemesanan Lapangan"*.
  - Input field: TextBox Username & TextBox Password (`PasswordChar = "*"`), border slate 2px.
  - Tombol **"MASUK KE SISTEM →"**: Latar Mint Green (`#25C16F`), teks putih, tebal, dengan bayangan mekanis.
  - Label error dinamis: Kotak pill Coral (`#FFB5B5`) jika ada pesan gagal login / akun terkunci.

---

### 5.2 `frmMenuUtama` (Dasbor Taktil & Navigasi Operasional)
- **Ukuran**: 1024 × 700 px, `StartPosition = CenterScreen`
- **Header Atas (Floating Bar)**:
  - Container pill putih panjang berborder `#2D334A` dan bayangan 4px.
  - Kiri: Logo Kotak Coral (`#FFB5B5`) + Teks **"SIPELA"** (Fredoka/Segoe UI 14pt Bold).
  - Tengah: Teks selamat datang & info peran `[Nama Pengguna] • (Owner / Kasir)`.
  - Kanan: Pill Badge Status Koneksi Database (Hijau Mint) + Tombol Logout Coral (`#FFB5B5`).
- **Area Kartu Metrik Ringkas (Top Stats Row)**:
  - 4 Kartu Neo-Brutalist dengan sudut bayangan solid:
    1. **Total Lapangan**: Card Sky Blue (`#AED4E6`), angka besar bold.
    2. **Booking Hari Ini**: Card Mint Green (`#25C16F`), angka total slot aktif hari ini.
    3. **Menunggu Konfirmasi DP**: Card Coral (`#FFB5B5`), peringatan booking belum bayar.
    4. **Pendapatan Bulan Ini**: Card Lavender (`#D8D4F2`), format mata uang Rupiah.
- **Grid Menu Navigasi Utama**:
  - 6 Kartu Aksi Berukuran Besar (Interactive Cards dengan ikon & deskripsi singkat):
    1. 📅 **Jadwal Lapangan** (`btnMenuJadwal`): Akses kalender matriks slot waktu.
    2. 📝 **Transaksi Pemesanan** (`btnMenuPemesanan`): Form input pemesanan & sewa lapangan.
    3. 💰 **Kasir & Pembayaran** (`btnMenuPembayaran`): Form pencatatan DP & Pelunasan.
    4. 📋 **Master Lapangan** (`btnMenuLapangan`): Khusus Owner untuk kelola tarif & jenis lapangan.
    5. 👤 **Master Pengguna** (`btnMenuUsers`): Khusus Owner untuk akun staf kasir.
    6. 📊 **Laporan & Rekap** (`btnMenuLaporan`): Grafik okupansi & ekspor laporan bulanan MoM.

---

### 5.3 `frmPemesanan` (Form Transaksi Booking Lapangan)
- **Ukuran**: 1100 × 720 px
- **Layout 2 Kolom**:
  - **Kolom Kiri (Input Pemesan & Parameter Sewa)**:
    - Card Putih border 2.5px slate:
      - Kode Booking (Auto-generated pill Lavender, read-only: `BKG-YYYYMMDD-XXXX`).
      - Nama Pemesan (TextBox tebal).
      - Nomor WhatsApp / HP (TextBox dengan validasi angka).
      - Tanggal Main (DateTimePicker dengan format kustom).
      - Lapangan (ComboBox dengan daftar lapangan aktif beserta tarif per jam).
      - Catatan Tambahan (TextBox multi-line).
  - **Kolom Kanan (Visual Slot Selector & Billing Summary)**:
    - **Interactive Slot Time Picker (08:00 s.d. 24:00)**:
      - Grid tombol-tombol slot jam (08.00, 09.00, ... 23.00).
      - Status Tombol Slot:
        * **Mint Green (`#25C16F`)**: Tersedia (Bisa diklik untuk memilih).
        * **Sky Blue (`#AED4E6`)**: Terpilih saat ini.
        * **Coral (`#FFB5B5`)**: Sudah terisi / booked (Disabled).
    - **Card Ringkasan Biaya (Bottom Summary Card)**:
      - Durasi Total: `X Jam`
      - Total Biaya Sewa: `Rp XXX.XXX` (Otomatis terhitung)
      - Minimal DP Wajib (30%): `Rp XXX.XXX` (Otomatis terhitung)
      - Batas Waktu Pembayaran DP: `+15 Menit` dari pembuatan
    - **Aksi Tombol**:
      - Tombol **"SIMPAN PEMESANAN"** (Mint Green, bayangan 4px).
      - Tombol **"LANJUT KE PEMBAYARAN →"** (Sky Blue, langsung buka kasir).
      - Tombol **"BATAL / BERSIHKAN"** (White surface, border slate).

---

### 5.4 `frmPembayaran` (Kasir, DP & Pelunasan)
- **Ukuran**: 1000 × 680 px
- **Struktur Tampilan**:
  - **Pencarian Cepat Booking**:
    - Input Pencarian: TextBox tebal untuk Kode Booking atau Nama Pemesan.
    - Tombol Cari Sky Blue (`#AED4E6`).
  - **Card Informasi Tagihan (Kiri)**:
    - Rincian Booking: Nama Pemesan, Lapangan, Tanggal Main, Jam Main.
    - Status Tagihan: Badge Pill (Menunggu DP / DP Terbayar / Lunas).
    - Total Tagihan, Sisa Tagihan (Pelunasan).
  - **Card Form Input Pembayaran (Kanan)**:
    - No Transaksi (Auto-generated: `PAY-YYYYMMDD-XXXX`).
    - Jenis Pembayaran: RadioButton Pill `[ ● Uang Muka (DP) ]` atau `[ ○ Pelunasan ]`.
    - Metode Pembayaran: ComboBox `[ Tunai | QRIS | Transfer Bank ]`.
    - Jumlah Diterima: NumericTextBox berformat ribuan.
    - Kembalian: Label besar tebal warna Dark Slate.
  - **Aksi Kasir**:
    - Tombol **"PROSES PEMBAYARAN"** (Mint Green `#25C16F`).
    - Tombol **"CETAK STRUK / NOTA"** (Sky Blue `#AED4E6`, memicu dialog cetak nota).

---

### 5.5 `frmJadwal` (Kalender Matriks Visual Slot Lapangan)
- **Ukuran**: 1180 × 740 px
- **Fitur Kontrol**:
  - Filter Bar Atas:
    - DateTimePicker tanggal jadwal dengan tombol panah cepat `[ < Hari Sebelumnya ]` dan `[ Hari Berikutnya > ]`.
    - Legend Badge Taktil:
      * 🟢 `[ ] Tersedia (Kosong)`
      * 🔴 `[ ] Terisi (DP / Lunas)`
      * 🟡 `[ ] Menunggu DP (Holding 15 Menit)`
  - **Matriks Jadwal (Schedule Matrix Board)**:
    - Sumbu X (Kolom): Lapangan A, Lapangan B, Lapangan C, dst.
    - Sumbu Y (Baris): Slot jam operasional (08.00–09.00 s.d. 23.00–00.00).
    - Sel Matriks: Tiap sel adalah kartu taktil kecil dengan teks nama pemesan dan status. Jika diklik, membuka detail pemesanan terkait.

---

### 5.6 `frmLaporan` (Dasbor Rekapitulasi & Ekspor Laporan)
- **Ukuran**: 1100 × 700 px
- **Struktur Antarmuka**:
  - Header Filter Periode: Pilihan Bulan & Tahun, filter jenis lapangan.
  - **3 Stat Cards Utama**:
    1. Total Pendapatan Bulan Terpilih (Card Mint Green).
    2. Tingkat Okupansi Lapangan (Card Sky Blue, persentase jam terpakai / total jam).
    3. Pertumbuhan Month-over-Month (MoM) (Card Lavender).
  - **Tabel Rekap DataGridView**: Menampilkan view `v_laporan_bulanan` / detail transaksi.
  - **Tombol Ekspor Taktil**:
    - Tombol **"EKSPOR EXCEL / CSV"** (Mint Green, ikon spreadsheet).
    - Tombol **"CETAK LAPORAN"** (Sky Blue).

---

## 6. Dialog Nota / Bukti Pembayaran (Struk)

- **Ukuran Struk**: 380 × 550 px (format slip termal 80mm atau struk dialog cetak).
- **Elemen Struk**:
  - Header: Logo **ARUNG FUTSAL**, Alamat, Kontak WhatsApp.
  - Garis pemisah putus-putus (`- - - - - - - - - - - - - - - -`).
  - No Transaksi & Kode Booking.
  - Detail Sewa (Nama, Lapangan, Tanggal, Jam).
  - Rincian Pembayaran (Jenis: DP / Pelunasan, Metode, Jumlah Bayar).
  - Status Akhir: **LUNAS** atau **DP TERBAYAR (Sisa: Rp ...)**.
  - Catatan Kaki: Ketentuan pembatalan sewa dan ucapan terima kasih.
