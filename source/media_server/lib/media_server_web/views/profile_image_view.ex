defmodule MediaServerWeb.ProfileImageView do
  use MediaServerWeb, :view
  alias MediaServerWeb.ProfileImageView

  def render("index.json", %{profile_image: profile_image}) do
    %{data: render_many(profile_image, ProfileImageView, "profile_image.json")}
  end

  def render("show.json", %{profile_image: profile_image}) do
    %{data: render_one(profile_image, ProfileImageView, "profile_image.json")}
  end

  def render("profile_image.json", %{profile_image: profile_image}) do
    %{id: profile_image.id,
      user: profile_image.user,
      image: profile_image.image}
  end
end
