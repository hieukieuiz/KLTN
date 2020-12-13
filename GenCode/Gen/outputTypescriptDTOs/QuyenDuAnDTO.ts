

import { QuyenDTO } from '@/models/QuyenDTO'; 

export interface QuyenDuAnDTO { 
    id: number;
    duAnId: number;
    quyenId: number;
    quyen: QuyenDTO;
}