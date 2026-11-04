# DESIGN — UI Design Specification

> **Versi**: 1.0 — Week 10 Deliverable  
> **Tanggal**: 4 November 2026  
> **Style**: Sederhana / Standard Windows Forms

---

## 1. Prinsip Desain

- **Sederhana dan fungsional** — prioritas pada keterbacaan dan kemudahan penggunaan
- **Konsisten** — semua form menggunakan layout dan gaya yang sama
- **Standard Windows Forms** — menggunakan kontrol bawaan tanpa custom styling berlebihan
- **Responsive labels** — label dan pesan error dalam Bahasa Indonesia

---

## 2. Palet Warna (Minimal)

| Elemen | Warna | Hex |
|--------|-------|-----|
| Form Background | Control (default) | `SystemColors.Control` |
| Panel Header | Dark Slate Blue | `#483D8B` |
| Header Text | White | `#FFFFFF` |
| Button Primary (Simpan) | Medium Sea Green | `#3CB371` |
| Button Edit (Ubah) | Steel Blue | `#4682B4` |
| Button Danger (Nonaktifkan) | Indian Red | `#CD5C5C` |
| Button Clear (Bersihkan) | Gray | `#808080` |
| Button Login | Dark Slate Blue | `#483D8B` |
| DataGridView Header | Dark Slate Blue | `#483D8B` |
| DataGridView Alternating Row | Lavender | `#E6E6FA` |

---

## 3. Form Specifications

### 3.1 `frmLogin`

```
┌─────────────────────────────────────┐
│         ██████████████████          │  ← Panel Header
│           SIPELA Login              │     Dark Slate Blue bg
│    Sistem Pemesanan Lapangan        │     White text
│         Arung Futsal                │
│         ██████████████████          │
│                                     │
│     Username: [________________]    │  ← TextBox txtUsername
│                                     │
│     Password: [________________]    │  ← TextBox txtPassword
│                                     │     PasswordChar = "*"
│              [    LOGIN    ]        │  ← Button btnLogin
│                                     │
│     Status: ____________________    │  ← Label lblStatus
│                                     │     (pesan error merah)
└─────────────────────────────────────┘
```

| Property | Value |
|----------|-------|
| Size | 400 × 350 |
| StartPosition | CenterScreen |
| FormBorderStyle | FixedDialog |
| MaximizeBox | False |
| MinimizeBox | False |
| AcceptButton | btnLogin |

### 3.2 `frmMenuUtama`

```
┌──────────────────────────────────────────────────────────┐
│ ┌──────────────────────────────────────────────────────┐ │
│ │  SIPELA — Sistem Pemesanan Lapangan Arung Futsal     │ │ ← Panel Header
│ │  Login sebagai: [NamaLengkap] (Role)                 │ │
│ └──────────────────────────────────────────────────────┘ │
│                                                          │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐   │
│  │  📋 Master   │  │  👤 Master   │  │  📅 Jadwal   │   │ ← Button grid
│  │  Lapangan    │  │   Users      │  │  (disabled)  │   │
│  └──────────────┘  └──────────────┘  └──────────────┘   │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐   │
│  │  🛒 Pemesanan│  │  💰 Pembayaran│ │  📊 Laporan  │   │
│  │  (disabled)  │  │  (disabled)  │  │  (disabled)  │   │
│  └──────────────┘  └──────────────┘  └──────────────┘   │
│                                                          │
│                          [  🚪 Logout  ]                 │ ← Button btnLogout
└──────────────────────────────────────────────────────────┘
```

| Property | Value |
|----------|-------|
| Size | 700 × 500 |
| StartPosition | CenterScreen |
| FormBorderStyle | FixedSingle |
| MaximizeBox | False |

### 3.3 `frmMasterLapangan`

```
┌────────────────────────────────────────────────────────────────────┐
│ ┌────────────────────────────────────────────────────────────────┐ │
│ │  Master Data Lapangan                                         │ │ ← Panel Header
│ └────────────────────────────────────────────────────────────────┘ │
│                                                                    │
│  ┌─ Input ─────────────────────────────┐  ┌─ Data ──────────────┐ │
│  │                                     │  │                     │ │
│  │  ID:             [____] (read-only) │  │  ┌─ DataGridView ─┐ │ │
│  │                                     │  │  │ ID | Nama | ... │ │ │
│  │  Nama Lapangan:  [________________]│  │  │  1 | Lap A | ...│ │ │
│  │                                     │  │  │  2 | Lap B | ...│ │ │
│  │  Jenis Lantai:   [________________]│  │  │  3 | Lap C | ...│ │ │
│  │                                     │  │  │                 │ │ │
│  │  Harga per Jam:  [▲ 100,000     ▼] │  │  │                 │ │ │
│  │                                     │  │  │                 │ │ │
│  │  Status:         [✓ Aktif]         │  │  └─────────────────┘ │ │
│  │                                     │  │                     │ │
│  │  [Simpan] [Ubah] [Nonaktifkan]     │  │  Cari: [________]   │ │
│  │  [Bersihkan]                        │  │                     │ │
│  │                                     │  │                     │ │
│  └─────────────────────────────────────┘  └─────────────────────┘ │
│                                                                    │
│  [← Kembali ke Menu]                                              │
└────────────────────────────────────────────────────────────────────┘
```

| Property | Value |
|----------|-------|
| Size | 900 × 550 |
| StartPosition | CenterScreen |
| FormBorderStyle | FixedSingle |
| MaximizeBox | False |

#### Kontrol Detail

| Nama di Form | Toolbox | Properties Name | Keterangan |
|-------------|---------|-----------------|------------|
| ID (read-only) | TextBox | txtIdLapangan | ReadOnly = True |
| Nama Lapangan | TextBox | txtNamaLapangan | MaxLength = 50 |
| Jenis Lantai | TextBox | txtJenisLantai | MaxLength = 50 |
| Harga per Jam | NumericUpDown | numHargaPerJam | Min=0, Max=MaxValue, ThousandsSeparator=True |
| Status Aktif | CheckBox | chkAktif | Checked = True (default) |
| Simpan | Button | btnSimpan | BackColor = MediumSeaGreen |
| Ubah | Button | btnUbah | BackColor = SteelBlue |
| Nonaktifkan | Button | btnNonaktifkan | BackColor = IndianRed |
| Bersihkan | Button | btnBersihkan | BackColor = Gray |
| Daftar Lapangan | DataGridView | dgvLapangan | ReadOnly, FullRowSelect |
| Pencarian | TextBox | txtCari | — |
| Kembali | Button | btnKembali | — |

### 3.4 `frmMasterUsers`

```
┌────────────────────────────────────────────────────────────────────┐
│ ┌────────────────────────────────────────────────────────────────┐ │
│ │  Master Data Users                                            │ │ ← Panel Header
│ └────────────────────────────────────────────────────────────────┘ │
│                                                                    │
│  ┌─ Input ─────────────────────────────┐  ┌─ Data ──────────────┐ │
│  │                                     │  │                     │ │
│  │  ID:             [____] (read-only) │  │  ┌─ DataGridView ─┐ │ │
│  │                                     │  │  │ ID|User|Nama|..│ │ │
│  │  Username:       [________________]│  │  │  1|owner|Own..|.│ │ │
│  │                                     │  │  │  2|admin|Adm..|.│ │ │
│  │  Password:       [________________]│  │  │                 │ │ │
│  │  (kosongkan jika tidak diubah)      │  │  │                 │ │ │
│  │                                     │  │  │                 │ │ │
│  │  Nama Lengkap:   [________________]│  │  └─────────────────┘ │ │
│  │                                     │  │                     │ │
│  │  Role:           [▼ Admin/Owner  ]  │  │  Cari: [________]   │ │
│  │                                     │  │                     │ │
│  │  [Simpan] [Ubah] [Nonaktifkan]     │  │                     │ │
│  │  [Bersihkan]                        │  │                     │ │
│  │                                     │  │                     │ │
│  └─────────────────────────────────────┘  └─────────────────────┘ │
│                                                                    │
│  [← Kembali ke Menu]                                              │
└────────────────────────────────────────────────────────────────────┘
```

| Property | Value |
|----------|-------|
| Size | 900 × 550 |
| StartPosition | CenterScreen |
| FormBorderStyle | FixedSingle |
| MaximizeBox | False |

#### Kontrol Detail

| Nama di Form | Toolbox | Properties Name | Keterangan |
|-------------|---------|-----------------|------------|
| ID (read-only) | TextBox | txtIdUser | ReadOnly = True |
| Username | TextBox | txtUsername | MaxLength = 50 |
| Password | TextBox | txtPassword | PasswordChar = "*", MaxLength = 50 |
| Hint password | Label | lblPasswordHint | ForeColor = Gray, kecil |
| Nama Lengkap | TextBox | txtNamaLengkap | MaxLength = 100 |
| Role | ComboBox | cmbRole | DropDownList, Items: Admin, Owner |
| Simpan | Button | btnSimpan | BackColor = MediumSeaGreen |
| Ubah | Button | btnUbah | BackColor = SteelBlue |
| Nonaktifkan | Button | btnNonaktifkan | BackColor = IndianRed |
| Bersihkan | Button | btnBersihkan | BackColor = Gray |
| Daftar Users | DataGridView | dgvUsers | ReadOnly, FullRowSelect |
| Pencarian | TextBox | txtCari | — |
| Kembali | Button | btnKembali | — |

---

## 4. Aturan DataGridView (Semua Form)

| Property | Value |
|----------|-------|
| ReadOnly | True |
| AllowUserToAddRows | False |
| AllowUserToDeleteRows | False |
| MultiSelect | False |
| SelectionMode | FullRowSelect |
| AutoSizeColumnsMode | Fill |
| RowHeadersVisible | False |
| ColumnHeadersDefaultCellStyle.BackColor | DarkSlateBlue |
| ColumnHeadersDefaultCellStyle.ForeColor | White |
| ColumnHeadersDefaultCellStyle.Font | Bold |
| AlternatingRowsDefaultCellStyle.BackColor | Lavender |

---

## 5. Aturan Tombol

| State | Simpan | Ubah | Nonaktifkan | Bersihkan |
|-------|--------|------|-------------|-----------|
| Mode Tambah (default) | ✅ Enabled | ❌ Disabled | ❌ Disabled | ✅ Enabled |
| Mode Edit (row diklik) | ❌ Disabled | ✅ Enabled | ✅ Enabled | ✅ Enabled |

