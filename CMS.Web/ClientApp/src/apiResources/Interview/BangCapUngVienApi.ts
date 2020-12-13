

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { BangCapUngVienDTO } from '@/models/Interview/BangCapUngVienDTO';
export interface GetBangCapUngVienParams extends Pagination {
   keywords? : string
}

class BangCapUngVienApi extends BaseApi {
    
    getBangCapUngVien(getBangCapUngVienParams: GetBangCapUngVienParams) {
        return new Promise<PaginatedResponse<BangCapUngVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/BangCapUngVien`, { params: getBangCapUngVienParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getBangCapUngVienById(id: number) {
        return new Promise<BangCapUngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/BangCapUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createBangCapUngVien(bangCapUngVienDTO: BangCapUngVienDTO) {
        return new Promise<BangCapUngVienDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/BangCapUngVien`,bangCapUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateBangCapUngVien(id: number, bangCapUngVienDTO: BangCapUngVienDTO) {
        return new Promise<BangCapUngVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/BangCapUngVien/${id}`,bangCapUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteBangCapUngVien(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/BangCapUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new BangCapUngVienApi();
