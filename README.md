# Run container local 

## build image
docker build -t item-api-img -f Baseline.ItemConfig.API/Dockerfile .

## run container
docker run -d --name itemconfig-api -p 7038:8081 --link LocalDB -e "ConnectionStrings__ItemConfigDb=Data Source=LocalDB,1433;Initial Catalog=ItemConfigDb;User ID=sa;Password=YourStrong!Pass123;Encrypt=True;TrustServerCertificate=True" -e "ASPNETCORE_ENVIRONMENT=Development" item-api-img
