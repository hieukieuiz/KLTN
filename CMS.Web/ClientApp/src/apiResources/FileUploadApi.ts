import { HTTP, HTTPDownload } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
var qs = require('qs');
export interface FileUploadApiSearchParams extends Pagination {

}
class FileUploadApi extends BaseApi {
    // ảnh
    upload(formData: FormData) {
        return new Promise<any>((resolve: any, reject: any) => {
            HTTP.post(`api/fileupload/upload`, formData, { headers: { 'Content-Type': 'multipart/form-data' } })
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }

    // tài liệu
    uploadFile(formData: FormData) {
        return new Promise<any>((resolve: any, reject: any) => {
            HTTP.post(`api/fileupload/upload/file`, formData, { headers: { 'Content-Type': 'multipart/form-data' } })
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
}
export default new FileUploadApi();
