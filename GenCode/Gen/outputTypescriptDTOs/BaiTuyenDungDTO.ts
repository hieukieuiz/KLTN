

import { DoanhNghiepDTO } from '@/models/DoanhNghiepDTO';
import { UngTuyenDTO } from '@/models/UngTuyenDTO';
import { YeuCauDTO } from '@/models/YeuCauDTO'; 

export interface BaiTuyenDungDTO { 
    id: number;
    doanhNghiepId: number;
    tieuDe: string;
    anhDaiDien: string;
    kyHieu: string;
    linkAnhMinhHoa: string;
    hienThi: boolean;
    gioiThieu: string;
    ngayDang: string;
    soLuongTuyen: string;
    thanhPho: string;
    mucLuong: string;
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
    ungTuyen: UngTuyenDTO[];
    yeuCau: YeuCauDTO[];
}