

import { TinhThanhDTO } from '@/models/TinhThanhDTO'; 

export interface HocVienDTO { 
    id: number;
    tinhThanhId: number;
    hoTen: string;
    ngaySinh: Date;
    sdt: string;
    account: string;
    email: string;
    tinhThanh: TinhThanhDTO;
}