

import { BaiTuyenDungDTO } from '@/models/BaiTuyenDungDTO';
import { UngVienDTO } from '@/models/UngVienDTO'; 

export interface UngTuyenDTO { 
    id: number;
    ngayUngTuyen: Date;
    ketQua: string;
    danhGiaCuaNhaTuyenDung: string;
    baiTuyenDung: BaiTuyenDungDTO;
    ungVien: UngVienDTO;
}