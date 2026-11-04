# APP-FLOW — Application Flow

> **Versi**: 1.0 — Week 10 Deliverable  
> **Tanggal**: 4 November 2026

---

## 1. Alur Utama Aplikasi (Week 10)

```mermaid
flowchart TD
    A["App Start"] --> B["frmLogin"]
    B --> C{"Login berhasil?"}
    C -->|Tidak| D["Tampilkan error / Lock akun"]
    D --> B
    C -->|Ya - Owner| E["frmMenuUtama (Owner)"]
    C -->|Ya - Admin| F["frmMenuUtama (Admin)"]
    
    E --> G["Menu: Master Lapangan"]
    E --> H["Menu: Master Users"]
    E --> I["Menu: Jadwal (future)"]
    E --> J["Menu: Laporan (future)"]
    E --> K["Logout → frmLogin"]
    
    F --> L["Menu: Pemesanan (future)"]
    F --> M["Menu: Pembayaran (future)"]
    F --> N["Menu: Jadwal (future)"]
    F --> O["Menu: Riwayat (future)"]
    F --> P["Logout → frmLogin"]
    
    G --> Q["frmMasterLapangan"]
    H --> R["frmMasterUsers"]
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
    I -->|Ya, belum expired| J["MessageBox: akun terkunci, coba lagi setelah X menit"]
    J --> A
    I -->|Tidak / sudah expired| K["Hash input password dengan SHA-256"]
    K --> L{"Hash cocok?"}
    L -->|Tidak| M["Increment gagal_login"]
    M --> N{"gagal_login >= 5?"}
    N -->|Ya| O["Set terkunci_sampai = NOW() + 15 menit"]
    O --> P["MessageBox: akun dikunci 15 menit"]
    P --> A
    N -->|Tidak| F
    L -->|Ya| Q["Reset gagal_login = 0"]
    Q --> R["Simpan ke ModSesi: id, username, nama, role"]
    R --> S["Hide frmLogin"]
    S --> T["Show frmMenuUtama"]
```

### Detail Validasi Login

| Step | Validasi | Aksi Gagal |
|------|----------|-----------|
| 1 | Username dan password tidak boleh kosong | MessageBox warning |
| 2 | Cari user berdasarkan username (case-insensitive) | "Username atau password salah" |
| 3 | Cek `is_active = TRUE` | "Akun tidak aktif, hubungi Owner" |
| 4 | Cek `terkunci_sampai` < NOW() atau NULL | "Akun terkunci, coba lagi setelah X menit" |
| 5 | Bandingkan SHA-256 hash | "Username atau password salah" + increment gagal |
| 6 | Jika `gagal_login >= 5` → kunci 15 menit | Set `terkunci_sampai` |
| 7 | Login berhasil → reset `gagal_login`, set session | Redirect ke Menu Utama |

---

## 3. Alur Menu Utama (`frmMenuUtama`)

```mermaid
flowchart LR
    A["frmMenuUtama"] --> B{"ModSesi.Role?"}
    B -->|Owner| C["Enable: Master Lapangan, Master Users, Jadwal*, Laporan*"]
    B -->|Admin| D["Enable: Pemesanan*, Pembayaran*, Jadwal*, Riwayat*"]
    C --> E["Disable: Pemesanan*, Pembayaran*, Riwayat*"]
    D --> F["Disable: Master Lapangan, Master Users, Laporan*"]
```

> *Bertanda asterisk (\*) = form belum dibuat di Week 10, menu tampil tapi disabled/placeholder*

### Menu Mapping

| Menu Item | Owner | Admin | Form Target | Status Week 10 |
|-----------|-------|-------|-------------|----------------|
| Master Lapangan | ✅ Enabled | ❌ Disabled | `frmMasterLapangan` | ✅ Implementasi |
| Master Users | ✅ Enabled | ❌ Disabled | `frmMasterUsers` | ✅ Implementasi |
| Pemesanan | ❌ Disabled | ✅ Enabled | `frmPemesanan` | ⏳ Future |
| Pembayaran | ❌ Disabled | ✅ Enabled | `frmPembayaran` | ⏳ Future |
| Jadwal | ✅ Enabled | ✅ Enabled | `frmJadwal` | ⏳ Future |
| Laporan | ✅ Enabled | ❌ Disabled | `frmLaporan` | ⏳ Future |
| Riwayat | ❌ Disabled | ✅ Enabled | `frmLaporan` | ⏳ Future |
| Logout | ✅ Enabled | ✅ Enabled | → `frmLogin` | ✅ Implementasi |

---

## 4. Alur CRUD Master Lapangan (`frmMasterLapangan`)

```mermaid
flowchart TD
    A["Form Load"] --> B["Load DataGridView dari tabel lapangan"]
    A --> C["Set field read-only / default values"]
    
    subgraph CRUD
        D["Tambah Lapangan"]
        E["Ubah Lapangan"]
        F["Nonaktifkan Lapangan"]
        G["Bersihkan Form"]
    end
    
    D --> D1["Validasi input"]
    D1 --> D2{"Valid?"}
    D2 -->|Tidak| D3["Tampilkan error validasi"]
    D2 -->|Ya| D4["INSERT ke tabel lapangan"]
    D4 --> D5["Refresh DataGridView"]
    D5 --> D6["Bersihkan form"]
    
    E --> E1["Pilih baris di DataGridView"]
    E1 --> E2["Populate field dengan data terpilih"]
    E2 --> E3["Edit field"]
    E3 --> E4["Validasi input"]
    E4 --> E5{"Valid?"}
    E5 -->|Tidak| E6["Tampilkan error validasi"]
    E5 -->|Ya| E7["UPDATE tabel lapangan"]
    E7 --> E8["Refresh DataGridView"]
    
    F --> F1["Pilih baris di DataGridView"]
    F1 --> F2["Konfirmasi nonaktifkan"]
    F2 --> F3["UPDATE is_active = FALSE"]
    F3 --> F4["Refresh DataGridView"]
```

### Validasi Master Lapangan

| Field | Validasi | Pesan Error |
|-------|----------|-------------|
| Nama Lapangan | Wajib diisi, unik | "Nama lapangan wajib diisi" / "Nama lapangan sudah ada" |
| Jenis Lantai | Wajib diisi | "Jenis lantai wajib diisi" |
| Harga per Jam | Wajib > 0 | "Harga per jam harus lebih dari 0" |

---

## 5. Alur CRUD Master Users (`frmMasterUsers`)

```mermaid
flowchart TD
    A["Form Load"] --> B["Load DataGridView dari tabel users"]
    A --> C["Set field defaults, ComboBox role"]
    
    subgraph CRUD
        D["Tambah User"]
        E["Ubah User"]
        F["Nonaktifkan User"]
        G["Bersihkan Form"]
    end
    
    D --> D1["Validasi input"]
    D1 --> D2{"Valid?"}
    D2 -->|Tidak| D3["Tampilkan error validasi"]
    D2 -->|Ya| D4["Hash password SHA-256"]
    D4 --> D5["INSERT ke tabel users"]
    D5 --> D6["Refresh DataGridView"]
    
    E --> E1["Pilih baris di DataGridView"]
    E1 --> E2["Populate field (password kosong)"]
    E2 --> E3["Edit field"]
    E3 --> E4["Validasi input"]
    E4 --> E5{"Password diisi?"}
    E5 -->|Ya| E6["Hash password baru"]
    E5 -->|Tidak| E7["Pertahankan hash lama"]
    E6 --> E8["UPDATE tabel users"]
    E7 --> E8
    E8 --> E9["Refresh DataGridView"]
    
    F --> F1["Pilih baris di DataGridView"]
    F1 --> F2{"User sendiri?"}
    F2 -->|Ya| F3["MessageBox: tidak bisa nonaktifkan diri sendiri"]
    F2 -->|Tidak| F4["Konfirmasi nonaktifkan"]
    F4 --> F5["UPDATE is_active = FALSE"]
    F5 --> F6["Refresh DataGridView"]
```

### Validasi Master Users

| Field | Validasi | Pesan Error |
|-------|----------|-------------|
| Username | Wajib diisi, min 4 karakter, unik | "Username wajib diisi" / "Username minimal 4 karakter" / "Username sudah digunakan" |
| Password | Wajib diisi saat tambah baru, min 6 karakter | "Password wajib diisi" / "Password minimal 6 karakter" |
| Nama Lengkap | Wajib diisi | "Nama lengkap wajib diisi" |
| Role | Wajib dipilih dari ComboBox | "Pilih role pengguna" |
| Nonaktifkan diri | Tidak boleh nonaktifkan akun sendiri | "Tidak dapat menonaktifkan akun Anda sendiri" |

---

## 6. Alur Logout

```mermaid
flowchart LR
    A["Klik Logout"] --> B["Konfirmasi: Yakin ingin logout?"]
    B -->|Tidak| C["Kembali ke menu"]
    B -->|Ya| D["ModSesi.Logout()"]
    D --> E["Close frmMenuUtama"]
    E --> F["Show frmLogin"]
```

