

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { PhanViecDTO } from '@/models/PhanViecDTO';
export interface GetPhanViecParams extends Pagination {
   congViecId : number
}
export interface GetPhanViecByHocVienAndCongViecParams extends Pagination {
   congViecId : number
}

class PhanViecApi extends BaseApi {
    
    getPhanViec(getPhanViecParams: GetPhanViecParams) {
        return new Promise<PaginatedResponse<PhanViecDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/PhanViec`, { params: getPhanViecParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createPhanViec(phanViecDTO: PhanViecDTO) {
        return new Promise<PhanViecDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/PhanViec`,phanViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deletePhanViec(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/PhanViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getPhanViecByHocVienAndCongViec(getPhanViecByHocVienAndCongViecParams: GetPhanViecByHocVienAndCongViecParams) {
        return new Promise<PaginatedResponse<PhanViecDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/PhanViec/user`, { params: getPhanViecByHocVienAndCongViecParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new PhanViecApi();
