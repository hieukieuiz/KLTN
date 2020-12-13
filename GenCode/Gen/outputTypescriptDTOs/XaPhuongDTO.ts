

import { QuanHuyenDTO } from '@/models/QuanHuyenDTO'; 

export interface XaPhuongDTO { 
    id: number;
    tenXaPhuong: string;
    quanHuyen: QuanHuyenDTO;
}