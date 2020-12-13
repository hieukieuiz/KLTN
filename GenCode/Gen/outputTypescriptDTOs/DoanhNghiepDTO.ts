

import { BaiTuyenDungDTO } from '@/models/BaiTuyenDungDTO'; 

export interface DoanhNghiepDTO { 
    id: number;
    ngayUngTuyen: Date;
    tenDoanhNghiep: string;
    logoDoanhNghiep: string;
    account: string;
    sđt: string;
    email: string;
    diaChi: string;
    gioiThieu: string;
    baiTuyenDung: BaiTuyenDungDTO[];
}