# visulizeJSONdata

## How to Run with Docker

1.  **Navigate to the project directory**
    Open a terminal or command prompt and navigate to this project's root folder.

2.  **Build the Docker image**
    This command packages the application into a self-contained image named `visualizejsondata`.
    ```sh
    docker build -t visualizejsondata .
    ```

3.  **Run the Docker container**
    This command starts the application from the image you just built. It will be accessible on port `5100` of your local machine.
    ```sh
    docker run -p 5100:8080 --name my-json-app visualizejsondata
    ```

4.  **Access the application**
    Open your web browser and go to the following URLs:
    *   **Table View:** [http://localhost:5100](http://localhost:5100)
    *   **Chart View:** [http://localhost:5100/Chart](http://localhost:5100/Chart)

To stop and remove the running container, open a new terminal and run:
```sh
docker stop my-json-app
docker rm my-json-app
```
