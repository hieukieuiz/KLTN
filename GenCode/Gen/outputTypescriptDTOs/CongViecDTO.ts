

import { DuAnDTO } from '@/models/DuAnDTO';
import { TrangThaiDTO } from '@/models/TrangThaiDTO';
import { string[] } from '@/models/string[]';
import { ChiTietCongViecDTO } from '@/models/ChiTietCongViecDTO'; 

export interface CongViecDTO { 
    id: number;
    duAnId: number;
    duAn: DuAnDTO;
    trangThaiId: number;
    trangThai: TrangThaiDTO;
    loaiCongViecId: number;
    tenCongViec: string;
    ngayTao: Date;
    ngayHetHan: Date;
    tyLeHoanThanh: number;
    moTaCongViec: string[];
    doUuTien: string;
    ngayHoanThanh: Date;
    ngayCapNhat: Date;
    isActive: boolean;
    thanhVienDuAnId: number;
    soLuongChiTietCongViec: number;
    soLuongChiTietCongViecHoanThanh: number;
    chiTietCongViec: ChiTietCongViecDTO[];
}