import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from '../services/environment-url.service';
import { BaseService } from '../services/base.service';
import { CreatePost, UpdatePost, Post, PagingQuery } from '../../../models/index';

@Injectable()
export class PostService extends BaseService {

    private urlPath = 'api/ActivityPost';

    constructor(protected http: HttpClient, protected envUrl: EnvironmentUrlService) {
        super(http, envUrl);
    }

    public getAll(pagingQuery: PagingQuery) {
        return this.getData(this.urlPath + pagingQuery.toQuery());
    }

    public getById(id: string) {
        return this.getData(this.urlPath + '/' + id);
    }

    public createPost(createPost: CreatePost) {
        return this.create(this.urlPath, createPost);
    }

    public updatePost(updatePost: UpdatePost) {
        return this.update(this.urlPath, updatePost);
    }

    public deletePost(id: string) {
        return this.delete(this.urlPath + '/' + id);
    }
}
