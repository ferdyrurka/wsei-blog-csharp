# Blog C#

## Database type

*In memory*

## Endpoints

#### Add post

**HTTP method**: POST
**URL**: /api/add-post
**Body**:
```json
{
	"title": "Title post",
	"content": "Hello World"
}
```
**Example return**:
```json
{
    "id": 6,
    "title": "Title post",
    "content": "Hello World"
}
```

#### Calculate popular post

**HTTP method**: GET
**URL**: /api/calculate-popular-posts/{max-result}
**Example URL**: /api/calculate-popular-posts/3
**Body**:
```json
{
    "PostsStatistics": [
        {
        	"PostId": "0cc175b9c0f1b6a831c399e269772661",
            "Views": 130300,
            "Conversions": 53287,
            "ReadTime": 223000.99
        },
        {
        	"PostId": "92eb5ffee6ae2fec3ad71c777531578f",
            "Views": 26986,
            "Conversions": 7000,
            "ReadTime": 9981.6
        },
        {
        	"PostId": "4a8a08f09d37b73795649038408b5f33",
            "Views": 9723,
            "Conversions": 7875,
            "ReadTime": 20449
        },
        {
        	"PostId": "8277e0910d750195b448797616e091ad",
            "Views": 54872,
            "Conversions": 25875,
            "ReadTime": 90999.4
        }
    ]
}
```
**Example return**:
```json
{
    "0cc175b9c0f1b6a831c399e269772661": 0.43450635938633536,
    "8277e0910d750195b448797616e091ad": 0.19252864560416053,
    "92eb5ffee6ae2fec3ad71c777531578f": 0.05959463141039529
}
```


## Author

Łukasz Staniszewski <kontakt@lukaszstaniszewski.pl>
