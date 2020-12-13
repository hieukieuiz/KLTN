

import { string[] } from '@/models/string[]';
import { TrangThaiDuAnDTO } from '@/models/TrangThaiDuAnDTO';
import { CongViecDTO } from '@/models/CongViecDTO'; 

export interface DuAnDTO { 
    id: number;
    tenDuAn: string;
    thoiGianTao: Date;
    thoiGianCapNhat: Date;
    thoiGianHetHan: Date;
    moTa: string[];
    soThuTu: number;
    soLuongThanhVien: number;
    trangThaiDuAn: TrangThaiDuAnDTO[];
    congViec: CongViecDTO[];
}