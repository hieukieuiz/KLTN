

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { KyNangDTO } from '@/models/Interview/KyNangDTO';
export interface GetKyNangParams extends Pagination {
   keywords? : string
}

class KyNangApi extends BaseApi {
    
    getKyNang(getKyNangParams: GetKyNangParams) {
        return new Promise<PaginatedResponse<KyNangDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/KyNang`, { params: getKyNangParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getKyNangById(id: number) {
        return new Promise<KyNangDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/KyNang/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createKyNang(kyNangDTO: KyNangDTO) {
        return new Promise<KyNangDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/KyNang`,kyNangDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateKyNang(id: number, kyNangDTO: KyNangDTO) {
        return new Promise<KyNangDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/KyNang/${id}`,kyNangDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteKyNang(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/KyNang/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new KyNangApi();
