export class PagingQuery {
    public pageSize = 0;
    public pageNumber = 0;
    public search = '';

    public toQuery(): string {
        if (this.search !== '' && !!this.search) {
            return '?pageNumber=' + this.pageNumber + '&pageSize=' + this.pageSize + '&search=' + this.search;
        } else {
            return '?pageNumber=' + this.pageNumber + '&pageSize=' + this.pageSize;
        }
    }
}
