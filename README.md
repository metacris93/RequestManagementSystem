docker-compose build

https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-7.0

dotnet dev-certs https --clean

dotnet dev-certs https -ep ${HOME}/.aspnet/https/RequestService.pfx -p "request-service"
dotnet dev-certs https --trust

dotnet user-secrets -p Services/Request/RequestService.csproj set "Kestrel:Certificates:Development:Password" "request-service"

instalar kubectl y minikube

kubectl apply -f k8s/request-service-deployment.yaml
kubectl apply -f k8s/request-np-srv.yaml

kubectl delete deployments request-service-deployment

minikube image ls