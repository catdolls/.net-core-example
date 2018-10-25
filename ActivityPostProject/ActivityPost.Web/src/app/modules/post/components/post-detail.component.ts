import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PostService } from '../../../modules/core/services';
import { CreatePost, UpdatePost, Post } from '../../../models';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post.component.css']
})
export class PostDetailComponent implements OnInit {

  public titleErrorMessage = '';
  public descriptionErrorMessage = '';
  public authorErrorMessage = '';
  public formText = '';
  public saveButtonText = '';

  public model = new Post();

  constructor(
    private postService: PostService,
    private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    const id = this.activeRoute.snapshot.params['id'];

    if (id) {
      this.formText = 'Edit post';
      this.saveButtonText = 'SAVE';
      this.getPost(id);
    } else {
      this.formText = 'Add post';
      this.saveButtonText = 'ADD';
      this.model = new Post();
    }
  }

  public save() {
    if (!this.validate()) {
      return false;
    }

    if (this.model.id) {
      this.update();
    } else {
      this.create();
    }
  }

  private validate(): boolean {
    this.titleErrorMessage = '';
    this.descriptionErrorMessage = '';
    this.authorErrorMessage = '';

    if (!this.model.title) {
      this.titleErrorMessage = 'Title is required.';
    }
    if (!!this.model.title && this.model.title.length > 100) {
      if (!!this.titleErrorMessage) {
        this.titleErrorMessage = this.titleErrorMessage + ' Title is over 100 characters.';
      } else {
        this.titleErrorMessage = 'Title is over 100 characters.';
      }
    }
    if (!this.model.description) {
      this.descriptionErrorMessage = 'Description is required.';
    }
    if (!this.model.author) {
      this.authorErrorMessage = 'Author is required.';
    }

    return !this.titleErrorMessage && !this.descriptionErrorMessage && !this.authorErrorMessage;
  }

  private createNewCreatePostModel(): CreatePost {
    const createPostModel = new CreatePost();
    createPostModel.title = this.model.title;
    createPostModel.description = this.model.description;
    createPostModel.author = this.model.author;
    return createPostModel;
  }

  private createNewUpdatePostModel(): UpdatePost {
    const updatePostModel = new UpdatePost();
    updatePostModel.id = this.model.id;
    updatePostModel.title = this.model.title;
    updatePostModel.description = this.model.description;
    updatePostModel.author = this.model.author;
    return updatePostModel;
  }

  private create() {
    this.postService.createPost(this.createNewCreatePostModel())
      .subscribe((res: any) => {
          this.router.navigate(['/post/list/']);
      });
  }

  private update() {
    this.postService.updatePost(this.createNewUpdatePostModel())
      .subscribe((res: any) => {
          this.getPost(this.model.id);
      });
  }

  private getPost(id: string) {
    this.postService.getById(id)
      .subscribe((res: any) => {
          this.model = res as Post;
      });
  }
}
