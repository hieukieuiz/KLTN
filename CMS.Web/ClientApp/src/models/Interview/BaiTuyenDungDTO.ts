

import { DoanhNghiepDTO } from '@/models/Interview/DoanhNghiepDTO';
import { TrangThaiDTO } from '@/models/TrangThaiDTO'; 

export interface BaiTuyenDungDTO { 
    id: number;
    doanhNghiepId: number;
    tieuDe: string;
    ngayDang: string;
    soLuongTuyen: string;
    thanhPho: string;
    mucLuong: string;
    gioiThieu: string;
    kinhNghiem: string;
    gioiTinh: string;
    trinhDo: string;
    tinhChatCongViec: string;
    hinhThuc: string;
    thoiGianThuViec: string;
    nganhNghe: string;
    moTa: string;
    quyenLoi: string;
    doanhNghiep: DoanhNghiepDTO;
    trangThai: TrangThaiDTO;
}