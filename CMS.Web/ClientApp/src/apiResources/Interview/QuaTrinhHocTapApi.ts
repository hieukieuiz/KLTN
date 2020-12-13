

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { QuaTrinhHocTapDTO } from '@/models/Interview/QuaTrinhHocTapDTO';
export interface GetQuaTrinhHocTapParams extends Pagination {
   keywords? : string
}

class QuaTrinhHocTapApi extends BaseApi {
    
    getQuaTrinhHocTap(getQuaTrinhHocTapParams: GetQuaTrinhHocTapParams) {
        return new Promise<PaginatedResponse<QuaTrinhHocTapDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/QuaTrinhHocTap`, { params: getQuaTrinhHocTapParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getQuaTrinhHocTapById(id: number) {
        return new Promise<QuaTrinhHocTapDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/QuaTrinhHocTap/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createQuaTrinhHocTap(quaTrinhHocTapDTO: QuaTrinhHocTapDTO) {
        return new Promise<QuaTrinhHocTapDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/QuaTrinhHocTap`,quaTrinhHocTapDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateQuaTrinhHocTap(id: number, quaTrinhHocTapDTO: QuaTrinhHocTapDTO) {
        return new Promise<QuaTrinhHocTapDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/QuaTrinhHocTap/${id}`,quaTrinhHocTapDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteQuaTrinhHocTap(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/QuaTrinhHocTap/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new QuaTrinhHocTapApi();
