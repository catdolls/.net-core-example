import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from '../../core/services';
import { PagingQuery, Post, PostPagingResult } from '../../../models';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post.component.css']
})
export class PostListComponent implements OnInit {
    public posts: Post[] = [];
    public pagingQuery = new PagingQuery();
    public pagingResult = new PostPagingResult();

    constructor(private postService: PostService,
        private router: Router) { }

    ngOnInit() {
        this.getPosts();
    }

    public goToAddPost() {
        const detailsUrl = `/post/details/`;
        this.router.navigate([detailsUrl]);
    }

    public search() {
        this.getPosts();
    }

    public goToUpdatePost(id: string) {
        const detailsUrl = `/post/details`;
        this.router.navigate([detailsUrl, id]);
    }

    public delete(id: string) {
        this.postService.deletePost(id)
            .subscribe((res: any) => {
               this.getPosts();
            });
    }

    private getPosts() {
        this.postService.getAll(this.pagingQuery)
            .subscribe((res: any) => {
                this.posts = [];
                this.pagingResult.updateObjectFromJson(res);

                res.items.forEach(element => {
                    this.posts.push(new Post().deserialize(element));
                });
            });
    }
}
