

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { NhomKyNangDTO } from '@/models/Interview/NhomKyNangDTO';
export interface GetNhomKyNangParams extends Pagination {
   keywords? : string
}

class NhomKyNangApi extends BaseApi {
    
    getNhomKyNang(getNhomKyNangParams: GetNhomKyNangParams) {
        return new Promise<PaginatedResponse<NhomKyNangDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/NhomKyNang`, { params: getNhomKyNangParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getNhomKyNangById(id: number) {
        return new Promise<NhomKyNangDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/NhomKyNang/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createNhomKyNang(nhomKyNangDTO: NhomKyNangDTO) {
        return new Promise<NhomKyNangDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/NhomKyNang`,nhomKyNangDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateNhomKyNang(id: number, nhomKyNangDTO: NhomKyNangDTO) {
        return new Promise<NhomKyNangDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/NhomKyNang/${id}`,nhomKyNangDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteNhomKyNang(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/NhomKyNang/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new NhomKyNangApi();
