

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { HocVienDTO } from '@/models/HocVienDTO';
export interface GetHocVienParams extends Pagination {
   keywords? : string
   tinhThanhId? : number
}

class HocVienApi extends BaseApi {
    
    getHocVien(getHocVienParams: GetHocVienParams) {
        return new Promise<PaginatedResponse<HocVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/HocVien`, { params: getHocVienParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getHocVienById(id: number) {
        return new Promise<HocVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/HocVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createHocVien(hocVienDTO: HocVienDTO) {
        return new Promise<HocVienDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/HocVien`,hocVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateHocVien(id: number, hocVienDTO: HocVienDTO) {
        return new Promise<HocVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/HocVien/${id}`,hocVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteHocVien(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/HocVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new HocVienApi();
