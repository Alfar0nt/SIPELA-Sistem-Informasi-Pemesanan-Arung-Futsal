# APP-FLOW — Application Flow & User Journeys

> **Versi**: 2.1 — Full Operational Architecture  
> **Tanggal**: 5 November 2026  
> **Status**: Fase Operasional Inti Selesai (Fase 9 s.d. 15)

---

## 1. Alur Navigasi Utama Sistem

```mermaid
flowchart TD
    Start(["Aplikasi Dimulai"]) --> Login["frmLogin"]
    Login --> AuthCheck{"Autentikasi Berhasil?"}
    AuthCheck -->|Gagal 5x berturut-turut| Lockout["Akun Terkunci 15 Menit"]
    Lockout --> Login
    AuthCheck -->|Gagal < 5x| ErrMsg["Tampilkan Pesan Error"] --> Login
    
    AuthCheck -->|Berhasil| Sesi["Inisialisasi ModSesi"]
    Sesi --> MenuUtama["frmMenuUtama (Dasbor Taktil)"]
    
    MenuUtama -->|Cek Peran| RoleCheck{"Peran Pengguna?"}
    
    RoleCheck -->|Owner| OwnerNav["Akses Penuh: Master Lapangan, Master Users, Jadwal, Pemesanan, Pembayaran, Laporan"]
    RoleCheck -->|Admin/Kasir| AdminNav["Akses Operasional: Jadwal, Pemesanan, Pembayaran, Cetak Nota (Master Lapangan & Users dibatasi)"]
    
    OwnerNav --> ModLap["frmMasterLapangan"]
    OwnerNav --> ModUser["frmMasterUsers"]
    OwnerNav --> ModLapView["frmLaporan"]
    
    AdminNav --> ModBkg["frmPemesanan"]
    AdminNav --> ModPay["frmPembayaran"]
    AdminNav --> ModSch["frmJadwal"]
    
    OwnerNav --> ModBkg
    OwnerNav --> ModPay
    OwnerNav --> ModSch

    MenuUtama --> Logout["Logout"] --> Login
```

---

## 2. Alur Transaksi Pemesanan (`frmPemesanan`)

```mermaid
flowchart TD
    OpenBkg["Buka frmPemesanan"] --> InitBkg["Generate Kode Booking Otomatis (ModAutoNumber) & Set Default Tanggal Hari Ini"]
    InitBkg --> InputCust["Admin Mengisi: Nama Pemesan, No WhatsApp, Lapangan"]
    InputCust --> SelectDate["Pilih Tanggal Main"]
    SelectDate --> LoadSlots["Sistem Memuat Slot Jam 08.00 - 24.00 dari DB"]
    
    LoadSlots --> RenderGrid["Render Tombol Slot: Hijau (Tersedia), Merah (Terisi), Biru (Terpilih)"]
    RenderGrid --> ClickSlot["Kasir Mengklik 1 atau Beberapa Slot Tersedia"]
    
    ClickSlot --> Calc{"Kalkulasi Real-time"}
    Calc --> DisplayTotal["Hitung Total Durasi Jam<br>Hitung Total Sewa = Jam * Tarif<br>Hitung Minimal DP = 30% * Total Sewa<br>Set Batas Bayar = Waktu Dibuat + 15 Menit"]
    
    DisplayTotal --> ClickSave["Klik Tombol SIMPAN PEMESANAN"]
    ClickSave --> ValidateFields{"Validasi Field Lengkap & Slot Tidak Kosong?"}
    ValidateFields -->|Tidak| WarnField["Tampilkan Peringatan Validasi"] --> ClickSlot
    
    ValidateFields -->|Ya| CheckConflict{"Cek Ulang Ketersediaan Slot di DB"}
    CheckConflict -->|Terisi Orang Lain| CollisionErr["Pemberitahuan: Slot baru saja dipesan pihak lain!"] --> LoadSlots
    
    CheckConflict -->|Aman| DBTrans["Buka MySQL Transaction:<br>1. INSERT pemesanan (status: Menunggu DP)<br>2. INSERT detail_pemesanan (loop slot jam)"]
    DBTrans --> TransSuccess{"Transaksi Sukses?"}
    TransSuccess -->|Gagal| Rollback["Rollback Transaksi & Tampilkan Error"]
    TransSuccess -->|Berhasil| Commit["Commit Transaksi"]
    Commit --> PromptNext{"Ingin Langsung Proses Pembayaran DP?"}
    PromptNext -->|Ya| OpenPayDirect["Buka frmPembayaran dengan Kode Booking Terpilih"]
    PromptNext -->|Tidak| DoneBkg["Reset Form / Kembali ke Jadwal"]
```

---

## 3. Alur Kasir & Pembayaran (`frmPembayaran`)

```mermaid
flowchart TD
    OpenPay["Buka frmPembayaran"] --> FindBooking["Cari Berdasarkan Kode Booking atau Nama Pemesan"]
    FindBooking --> QueryBkg["Query Data Pemesanan & Detail Sewa"]
    QueryBkg --> Found{"Data Ditemukan?"}
    Found -->|Tidak| NotFoundMsg["Pemberitahuan: Data tidak ditemukan"] --> FindBooking
    
    Found -->|Ya| CheckStatus{"Status Saat Ini?"}
    CheckStatus -->|Lunas| InfoLunas["Tagihan sudah lunas. Sediakan opsi Cetak Ulang Nota"]
    CheckStatus -->|Kedaluwarsa| InfoExpired["Pemesanan kedaluwarsa karena melewati batas bayar"]
    CheckStatus -->|Menunggu DP| ModeDP["Set Mode Pembayaran = DP (Min. 30%)"]
    CheckStatus -->|DP Terbayar| ModePelunasan["Set Mode Pembayaran = Pelunasan (Sisa 70%)"]
    
    ModeDP --> SelectMethod["Pilih Metode: Tunai / QRIS / Transfer"]
    ModePelunasan --> SelectMethod
    
    SelectMethod --> InputAmount["Kasir Menginput Jumlah Diterima"]
    InputAmount --> CheckCash{"Metode Tunai?"}
    CheckCash -->|Ya| CalcChange["Hitung Kembalian = Diterima - Tagihan"]
    CheckCash -->|Tidak| ConfirmNonCash["Konfirmasi Mutasi / Bukti Transfer"]
    
    CalcChange --> ProcessPay["Klik PROSES PEMBAYARAN"]
    ConfirmNonCash --> ProcessPay
    
    ProcessPay --> ExecPay["Buka Transaksi Database:<br>1. INSERT ke pembayaran (no_transaksi PAY-...)<br>2. UPDATE pemesanan (status: DP Terbayar / Lunas)"]
    ExecPay --> PayDone["Pembayaran Berhasil Dicatat"]
    PayDone --> PrintDialog["Buka Dialog Cetak Nota (frmNotaPreview)"]
    PrintDialog --> PrintPhysical["Cetak Struk ke Printer Kasir / Simpan Bukti"]
```

---

## 4. Alur Kalender Matriks Jadwal (`frmJadwal`)

```mermaid
flowchart LR
    OpenJadwal["Buka frmJadwal"] --> PickDate["Pilih Tanggal Jadwal"]
    PickDate --> FetchSlots["Query view v_jadwal_lapangan"]
    FetchSlots --> BuildMatrix["Bangun Matriks Visual (Baris: Jam 08-24, Kolom: Lapangan)"]
    BuildMatrix --> UserClick{"Pengguna Mengklik Sel"}
    UserClick -->|Slot Terisi| ShowDetail["Tampilkan Pop-up Info Pemesan & Kontak"]
    UserClick -->|Slot Kosong| QuickBooking["Navigasi Cepat ke frmPemesanan dengan Slot Terpilih Otomatis"]
```

---

## 5. Alur Laporan & Analitik Bisnis (`frmLaporan`)

```mermaid
flowchart TD
    OpenLaporan["Buka frmLaporan (Khusus Owner)"] --> SelectFilter["Pilih Periode: Bulan & Tahun"]
    SelectFilter --> RunQueries["Query v_laporan_bulanan & v_okupansi_bulanan"]
    RunQueries --> RenderMetrics["Perbarui 3 Stat Cards:<br>1. Total Omzet Rupiah<br>2. Tingkat Okupansi %<br>3. Pertumbuhan MoM %"]
    RenderMetrics --> FillGrid["Populasi DataGridView dengan Rincian Transaksi"]
    
    FillGrid --> ExportOpt{"Pilihan Aksi"}
    ExportOpt -->|Ekspor Excel/CSV| GenCSV["Format Data Tabular ke Format CSV / Excel"] --> SaveFile["Simpan ke File Lokal"]
    ExportOpt -->|Cetak Ringkasan| GenReportView["Pratinjau Cetak Lembar Rekap Bulanan"]
```

---

## 6. Alur Background Maintenance (Auto-Expiration)

```mermaid
flowchart TD
    TimerTick["Background Timer Berdetak (Setiap 60 Detik)"] --> CheckExp["Panggil Stored Procedure sp_kedaluwarsakan_pemesanan()"]
    CheckExp --> FindOverdue["Identifikasi Pemesanan status 'Menunggu DP' dengan batas_bayar < NOW()"]
    FindOverdue --> AnyOverdue{"Ada Data yang Melewati Batas?"}
    AnyOverdue -->|Tidak| Sleep["Tidur hingga Detak Timer Berikutnya"]
    AnyOverdue -->|Ya| UpdateStatus["UPDATE status pemesanan = 'Kedaluwarsa'<br>UPDATE detail_pemesanan SET aktif = NULL"]
    UpdateStatus --> ReleaseSlots["Slot Waktu Otomatis Terlepas & Tersedia Kembali di Jadwal"]
    ReleaseSlots --> Sleep
```
