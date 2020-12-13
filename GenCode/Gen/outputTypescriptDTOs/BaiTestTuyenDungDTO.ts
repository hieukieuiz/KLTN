

import { BaiTuyenDungDTO } from '@/models/BaiTuyenDungDTO'; 

export interface BaiTestTuyenDungDTO { 
    id: number;
    diemPass: string;
    baiTuyenDung: BaiTuyenDungDTO[];
}