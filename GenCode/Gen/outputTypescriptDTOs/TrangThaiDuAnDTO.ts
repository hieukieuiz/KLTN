

import { TrangThaiDTO } from '@/models/TrangThaiDTO'; 

export interface TrangThaiDuAnDTO { 
    id: number;
    duAnId: number;
    trangThaiId: number;
    thoiGianTao: Date;
    trangThai: TrangThaiDTO;
    soLuongCongViec: number;
}