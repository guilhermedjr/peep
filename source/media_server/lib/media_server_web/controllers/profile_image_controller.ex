defmodule MediaServerWeb.ProfileImageController do
  use MediaServerWeb, :controller

  alias MediaServer.ProfileImages
  alias MediaServer.ProfileImages.ProfileImage

  action_fallback MediaServerWeb.FallbackController

  def index(conn, _params) do
    profile_image = ProfileImages.list_profile_image()
    render(conn, "index.json", profile_image: profile_image)
  end

  def create(conn, %{"profile_image" => profile_image_params}) do
    with {:ok, %ProfileImage{} = profile_image} <- ProfileImages.create_profile_image(profile_image_params) do
      conn
      |> put_status(:created)
      |> put_resp_header("location", Routes.profile_image_path(conn, :show, profile_image))
      |> render("show.json", profile_image: profile_image)
    end
  end

  def show(conn, %{"id" => id}) do
    profile_image = ProfileImages.get_profile_image!(id)
    render(conn, "show.json", profile_image: profile_image)
  end

  def update(conn, %{"id" => id, "profile_image" => profile_image_params}) do
    profile_image = ProfileImages.get_profile_image!(id)

    with {:ok, %ProfileImage{} = profile_image} <- ProfileImages.update_profile_image(profile_image, profile_image_params) do
      render(conn, "show.json", profile_image: profile_image)
    end
  end

  def delete(conn, %{"id" => id}) do
    profile_image = ProfileImages.get_profile_image!(id)

    with {:ok, %ProfileImage{}} <- ProfileImages.delete_profile_image(profile_image) do
      send_resp(conn, :no_content, "")
    end
  end
end
