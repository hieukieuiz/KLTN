

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { CVUngVienDTO } from '@/models/Interview/CVUngVienDTO';
export interface GetCVUngVienParams extends Pagination {
   keywords? : string
}

class CVUngVienApi extends BaseApi {
    
    getCVUngVien(getCVUngVienParams: GetCVUngVienParams) {
        return new Promise<PaginatedResponse<CVUngVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/CVUngVien`, { params: getCVUngVienParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getCVUngVienById(id: number) {
        return new Promise<CVUngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/CVUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createCVUngVien(cvUngVienDTO: CVUngVienDTO) {
        return new Promise<CVUngVienDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/CVUngVien`,cvUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateCVUngVien(id: number, cvUngVienDTO: CVUngVienDTO) {
        return new Promise<CVUngVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/CVUngVien/${id}`,cvUngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteCVUngVien(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/CVUngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new CVUngVienApi();
