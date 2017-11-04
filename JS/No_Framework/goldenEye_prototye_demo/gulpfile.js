const gulp = require('gulp');
const plumber = require('gulp-plumber');
const exec = require('child_process').exec;

// start lite server
gulp.task('lite-server', () => exec('npm run lite'));

// Watch SCSS files
gulp.task('watch', () => {
  gulp.watch('*/*.css');
  gulp.watch('*/*.js')
});

// default
gulp.task('default', ['watch', 'lite-server']);