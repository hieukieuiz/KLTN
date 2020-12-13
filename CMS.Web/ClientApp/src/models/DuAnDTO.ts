import { TrangThaiDuAnDTO } from './TrangThaiDuAnDTO';

export interface DuAnDTO
{
    id: number;
    tenDuAn: String;
    thoiGianTao: Date;
    thoiGianCapNhat?: Date;
    thoiGianHetHan?: Date;
    moTa?: String;
    soLuongThanhVien: number;
    linkQuanLiViec?:String;
    trangThaiDuAn: TrangThaiDuAnDTO[];
}