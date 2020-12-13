

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { KyNangUngVienDTO } from '@/models/Interview/KyNangUngVienDTO';
export interface GetKyNangUngVienParams extends Pagination {
   keywords? : string
}

class KyNangUngVienApi extends BaseApi {
    
    getKyNangUngVien(getKyNangUngVienParams: GetKyNangUngVienParams) {
        return new Promise<PaginatedResponse<KyNangUngVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/KyNangUngVien`, { params: getKyNangUngVienParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getKyNangUngVienById(id: number) {
        return new Promise<KyNangUngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/KyNangUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createKyNangUngVien(kyNangUngVienDTO: KyNangUngVienDTO) {
        return new Promise<KyNangUngVienDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/KyNangUngVien`,kyNangUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateKyNangUngVien(id: number, kyNangUngVienDTO: KyNangUngVienDTO) {
        return new Promise<KyNangUngVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/KyNangUngVien/${id}`,kyNangUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteKyNangUngVien(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/KyNangUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new KyNangUngVienApi();
