defmodule MediaServerWeb.ProfileImageController do
  use MediaServerWeb, :controller

  alias MediaServer.UserMedia
  alias MediaServer.UserMedia.ProfileImage

  def index(conn, _params) do
    profile_image = UserMedia.list_profile_image()
    render(conn, "index.html", profile_image: profile_image)
  end

  def new(conn, _params) do
    changeset = UserMedia.change_profile_image(%ProfileImage{})
    render(conn, "new.html", changeset: changeset)
  end

  def create(conn, %{"profile_image" => profile_image_params}) do
    case UserMedia.create_profile_image(profile_image_params) do
      {:ok, profile_image} ->
        conn
        |> put_flash(:info, "Profile image created successfully.")
        |> redirect(to: Routes.profile_image_path(conn, :show, profile_image))

      {:error, %Ecto.Changeset{} = changeset} ->
        render(conn, "new.html", changeset: changeset)
    end
  end

  def show(conn, %{"id" => id}) do
    profile_image = UserMedia.get_profile_image!(id)
    render(conn, "show.html", profile_image: profile_image)
  end

  def edit(conn, %{"id" => id}) do
    profile_image = UserMedia.get_profile_image!(id)
    changeset = UserMedia.change_profile_image(profile_image)
    render(conn, "edit.html", profile_image: profile_image, changeset: changeset)
  end

  def update(conn, %{"id" => id, "profile_image" => profile_image_params}) do
    profile_image = UserMedia.get_profile_image!(id)

    case UserMedia.update_profile_image(profile_image, profile_image_params) do
      {:ok, profile_image} ->
        conn
        |> put_flash(:info, "Profile image updated successfully.")
        |> redirect(to: Routes.profile_image_path(conn, :show, profile_image))

      {:error, %Ecto.Changeset{} = changeset} ->
        render(conn, "edit.html", profile_image: profile_image, changeset: changeset)
    end
  end

  def delete(conn, %{"id" => id}) do
    profile_image = UserMedia.get_profile_image!(id)
    {:ok, _profile_image} = UserMedia.delete_profile_image(profile_image)

    conn
    |> put_flash(:info, "Profile image deleted successfully.")
    |> redirect(to: Routes.profile_image_path(conn, :index))
  end
end
