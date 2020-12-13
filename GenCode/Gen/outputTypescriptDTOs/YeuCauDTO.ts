

import { BaiTuyenDungDTO } from '@/models/BaiTuyenDungDTO';
import { LoaiYeuCauDTO } from '@/models/LoaiYeuCauDTO'; 

export interface YeuCauDTO { 
    id: number;
    tenYeuCau: string;
    giaTriSoTu: string;
    giaTriSoDen: string;
    giaTriNoiDung: string;
    baiTuyenDung: BaiTuyenDungDTO;
    loaiYeuCau: LoaiYeuCauDTO;
}