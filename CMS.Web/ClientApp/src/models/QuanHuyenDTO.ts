

import { XaPhuongDTO } from '@/models/XaPhuongDTO';
import { TinhThanhDTO } from '@/models/TinhThanhDTO'; 

export interface QuanHuyenDTO { 
    id: number;
    tenQuanHuyen: string;
    xaPhuong: XaPhuongDTO[];
    tinhThanh: TinhThanhDTO;
}