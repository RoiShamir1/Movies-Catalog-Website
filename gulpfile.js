var gulp = require('gulp');
var log = require('fancy-log');
var uglify = require('gulp-uglify');
const sass = require('gulp-sass')(require('sass'));
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');

function myLog(msg) {
    log('**********');
    log(`*${msg}`);
    log('**********');
}

var paths = {
    src: {
        scripts: 'Scripts/*.js',
        styles: 'Styles/sass/*.*'
    },
    dest: {
        scripts: './wwwroot/js/',
        styles: './wwwroot/css/'
    }
};

gulp.task('sass', function () {
    myLog('Building application styles..');
    return gulp.src('./Styles/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('scripts', function () {
    return gulp.src('Scripts/**/*.js')
        // Minify the file
        .pipe(uglify())
        // Output
        .pipe(gulp.dest('wwwroot/js'));
});

gulp.task('watch', function () {
    myLog('Watching source files...');
    gulp.watch([paths.src.styles], gulp.parallel('sass'));
    gulp.watch([paths.src.styles], gulp.parallel('sass'));
});