const gulp = require('gulp');
const sass = require('gulp-sass');
const plumber = require('gulp-plumber');
const exec = require('child_process').exec;

// start lite server
gulp.task('lite-server', () => exec('npm run lite'));

// Watch JS
gulp.task('js', () => exec('npm run build'));

// SCSS -> CSS
gulp.task('scss', () => {
  return gulp.src('src/scss/**/*.scss')
    .pipe(plumber())
    .pipe(sass())
    .pipe(gulp.dest('dist/css/'));
});

// Watch SCSS and JS files
gulp.task('watch', () => {
  gulp.watch('src/js/*.js', ['js']);
  gulp.watch('src/scss/**/*.scss', ['scss']);
});

// default
gulp.task('default', ['watch', 'lite-server', 'js', 'scss']);