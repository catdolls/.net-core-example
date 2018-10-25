export abstract class PagingResult<TResult> {

    public pageNumber: number;
    public pageSize: number;
    public totalNumberOfPages: number;
    public totalNumberOfRecords: number;
    public totalNumberOfRecordsInCurrentPage: number;
    public results: Array<TResult>;

    public updateObjectFromJson = (jsonObject: any) => {
        this.pageNumber = jsonObject.paging.pageNumber;
        this.pageSize = jsonObject.paging.pageSize;
        this.totalNumberOfPages = jsonObject.paging.totalPages;
        this.totalNumberOfRecords = jsonObject.paging.totalItems;
        this.results = jsonObject.items;

        if (this.results == null) {
            this.totalNumberOfRecordsInCurrentPage = 0;
        } else {
            this.totalNumberOfRecordsInCurrentPage = this.results.length;
        }
    }
}
