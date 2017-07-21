
### Elasticsearch 
> index : testlog
> type : local

1. mapping
```json
{
  "mappings" : {
    "local" : {
    	"properties" : {
    		"logtime" : {
    			"type" : "date",
    			"format" : "yyyy-MM-dd HH:mm:ss"
    		}
    	}
    }
  }
}
```
2. schema

```json
{
    "domain": "local",
    "logtime": "",
    "auth": "",
    "log": {
        "error_code": "",
        "trace": "",
        "source": ""
    },
    "log_level": ""
}
```
---
