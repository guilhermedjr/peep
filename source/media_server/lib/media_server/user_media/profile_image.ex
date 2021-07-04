defmodule MediaServer.UserMedia.ProfileImage do
  use Ecto.Schema
  import Ecto.Changeset

  schema "profile_image" do
    field :imagePath, :string
    field :user, :string

    timestamps()
  end

  @doc false
  def changeset(profile_image, attrs) do
    profile_image
    |> cast(attrs, [:user, :imagePath])
    |> validate_required([:user, :imagePath])
  end
end
