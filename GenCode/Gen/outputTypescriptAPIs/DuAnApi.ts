

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { DuAnDTO } from '@/models/DuAnDTO';
export interface GetDuAnParams extends Pagination {
   keywords? : string
   hocVienId? : number
}

class DuAnApi extends BaseApi {
    
    getDuAn(getDuAnParams: GetDuAnParams) {
        return new Promise<PaginatedResponse<DuAnDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/DuAn`, { params: getDuAnParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getDuAnById(id: number) {
        return new Promise<DuAnDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/DuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createDuAn(duAnDTO: DuAnDTO) {
        return new Promise<DuAnDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/DuAn`,duAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateDuAn(id: number, duAnDTO: DuAnDTO) {
        return new Promise<DuAnDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/DuAn/${id}`,duAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteDuAn(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/DuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new DuAnApi();
