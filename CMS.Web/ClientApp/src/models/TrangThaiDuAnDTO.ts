import { TrangThaiDTO } from './TrangThaiDTO';

export interface TrangThaiDuAnDTO
{
    id: number;
    duAnID?: number;
    trangThaiID?: number;
    thoiGianTao: Date;
    soLuongCongViec: number;
    trangThai: TrangThaiDTO[];
}