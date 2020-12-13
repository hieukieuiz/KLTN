

import { Pagination } from '@/models/Pagination';

export interface PagedResult<T> { 
    pagination: Pagination;
    data: T[];
}